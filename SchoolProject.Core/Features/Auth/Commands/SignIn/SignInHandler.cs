using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Data.Entities.Identity;
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
        public SignInHandler(
            IStringLocalizer<SharedResource> localizer,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IAuthService authService
            )
            : base(localizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
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

            var UserRoles = await _userManager.GetRolesAsync(user);

            var (token, expiresIn) = _authService.GenerateTokenAsync(user, UserRoles);

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
    }
}
