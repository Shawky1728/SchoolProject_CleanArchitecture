using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Service.Abstract;
using System.Security.Cryptography;

namespace SchoolProject.Core.Features.Auth.Commands.GenerateRefreshToken
{
    public class GenerateRefreshTokenHandler : ResponseHandler, IRequestHandler<GenerateRefreshTokenCommand, Response<GenerateRefreshTokenResponse>>
    {
        private readonly UserManager<User> _userManager;
        private readonly int _refreshTokenExpiryDays = 7;
        private readonly IAuthService _authService;
        private readonly ApplicationDbContext _db;
        public GenerateRefreshTokenHandler(IStringLocalizer<SharedResource> localizer, UserManager<User> userManager, IAuthService authService, ApplicationDbContext db) : base(localizer)
        {
            _userManager = userManager;
            _authService = authService;
            _db = db;
        }

        public async Task<Response<GenerateRefreshTokenResponse>> Handle(GenerateRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var userId = _authService.ValidateToken(request.Token);

            if (userId == null)
            {
                return BadRequest<GenerateRefreshTokenResponse>(_localizer[SharedResourceKeys.BadRequest]);
            }

            var user = await _userManager.Users.Include(u => u.RefreshTokens).FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return BadRequest<GenerateRefreshTokenResponse>(_localizer[SharedResourceKeys.UserNotFound]);
            }


            var existingRefreshToken = user.RefreshTokens.FirstOrDefault(rt => (rt.Token == request.RefreshToken) && rt.IsActive);

            if (existingRefreshToken == null)
            {
                return BadRequest<GenerateRefreshTokenResponse>(_localizer[SharedResourceKeys.BadRequest]);
            }

            //revoke existing refresh token
            existingRefreshToken.RevokedAt = DateTime.UtcNow;

            var (userRoles, userPermissions) = await GetUserRolesAndPermissionsAsync(user, cancellationToken);

            //generate token
            var (newToken, expiresIn) = _authService.GenerateTokenAsync(user, userRoles, userPermissions);

            // generate Refresh Token 
            var newRefreshToken = GenerateRefreshToken();
            var refreshTokenExpiry = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

            //save refresh token
            user.RefreshTokens.Add(new RefreshToken
            {
                Token = newRefreshToken,
                ExpiresAt = refreshTokenExpiry
            });

            await _userManager.UpdateAsync(user);

            var response = new GenerateRefreshTokenResponse
            {
                Id = user.Id,
                Email = user.Email,
                Token = newToken,
                ExpiresIn = expiresIn,
                RefreshToken = new RefreshTokenResponse
                {
                    Token = newRefreshToken,
                    ExpiresAt = refreshTokenExpiry
                }
            };

            return Success(response, _localizer[SharedResourceKeys.CreatedSuccessfully]);
        }

        private static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

        private async Task<(IEnumerable<string> roles, IEnumerable<string> permissions)> GetUserRolesAndPermissionsAsync(User user, CancellationToken cancellationToken)
        {
            var userRoles = await _userManager.GetRolesAsync(user);


            //code with subquery
            var userpermissions = await (
                from role in _db.Roles
                join claim in _db.RoleClaims
                on role.Id equals claim.RoleId
                where userRoles.Contains(role.Name!)
                select claim.ClaimValue
                )
                .Distinct()
                .ToListAsync(cancellationToken);


            return (userRoles, userpermissions);
        }
    }
}
