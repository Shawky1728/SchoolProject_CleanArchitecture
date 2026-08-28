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

namespace SchoolProject.Core.Features.Auth.Commands.SignIn
{
    public class SignInHandler : ResponseHandler, IRequestHandler<SignInCommand, Response<SignInCommandResponse>>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly int _refreshTokenExpiryDays = 7;
        private readonly IAuthService _authService;
        private readonly ApplicationDbContext _db;
        public SignInHandler(
            IStringLocalizer<SharedResource> localizer,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IAuthService authService,
            ApplicationDbContext db
            )
            : base(localizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
            _db = db;
        }

        public async Task<Response<SignInCommandResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                return NotFound<SignInCommandResponse>(SharedResourceKeys.UserNotFound);
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);

            if (!signInResult.Succeeded)
            {
                return BadRequest<SignInCommandResponse>(SharedResourceKeys.InvalidCredentials);
            }

            var (UserRoles, UserPermissions) = await GetUserRolesAndPermissionsAsync(user, cancellationToken);

            var (token, expiresIn) = _authService.GenerateTokenAsync(user, UserRoles, UserPermissions);

            // generate Refresh Token 
            var refreshToken = GenerateRefreshToken();
            var refreshTokenExpiry = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

            var userRefreshToken = new RefreshToken
            {
                Token = refreshToken,
                ExpiresAt = refreshTokenExpiry
            };

            //save refresh token
            user.RefreshTokens.Add(userRefreshToken);
            await _userManager.UpdateAsync(user);

            var response = new SignInCommandResponse
            {
                Id = user.Id,
                Email = user.Email,
                Token = token,
                ExpiresIn = expiresIn,
                RefreshToken = new RefreshTokenResponse
                {
                    Token = refreshToken,
                    ExpiresAt = refreshTokenExpiry,
                }
            };

            return Success(response);

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
