using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Auth.Commands
{
    public class SignInHandler : ResponseHandler, IRequestHandler<SignInCommand, Response<SignInCommandResponse>>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
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

            var (token, expiresIn) = _authService.GenerateTokenAsync(user);

            var response = new SignInCommandResponse
            {
                Id = user.Id,
                Email = user.Email,
                Token = token,
                ExpiresIn = expiresIn
            };

            return Success(response);

        }
    }
}
