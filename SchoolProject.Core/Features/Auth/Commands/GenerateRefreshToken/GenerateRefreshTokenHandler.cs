using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Abstract;
using System.Security.Cryptography;

namespace SchoolProject.Core.Features.Auth.Commands.GenerateRefreshToken
{
    public class GenerateRefreshTokenHandler : ResponseHandler, IRequestHandler<GenerateRefreshTokenCommand, Response<GenerateRefreshTokenResponse>>
    {
        private readonly UserManager<User> _userManager;
        private readonly int _refreshTokenExpiryDays = 7;
        private readonly IAuthService _authService;
        public GenerateRefreshTokenHandler(IStringLocalizer<SharedResource> localizer, UserManager<User> userManager, IAuthService authService) : base(localizer)
        {
            _userManager = userManager;
            _authService = authService;
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

            var userRoles = await _userManager.GetRolesAsync(user);

            //generate token
            var (newToken, expiresIn) = _authService.GenerateTokenAsync(user, userRoles);

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
    }
}
