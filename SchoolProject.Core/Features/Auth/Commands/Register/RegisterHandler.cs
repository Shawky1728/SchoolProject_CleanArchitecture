using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Helper;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Sedding;
using SchoolProject.Service.Abstract;
using System.Text;

namespace SchoolProject.Core.Features.Auth.Commands.Register
{
    public class RegisterHandler : ResponseHandler, IRequestHandler<RegisterCommand, Response<string>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RegisterHandler(
            IStringLocalizer<SharedResource> localizer,
            UserManager<User> userManager,
            IEmailService emailService,
            IHttpContextAccessor httpContextAccessor) : base(localizer)
        {
            _userManager = userManager;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // check if email exists
            var isEmailExist = await _userManager.FindByEmailAsync(request.Email);
            if (isEmailExist != null)
            {
                return BadRequest<string>(_localizer[SharedResourceKeys.EmailExists]);
            }

            // create a new user entity
            var user = request.Adapt<User>();
            user.UserName = request.Email;

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(" ; ", result.Errors.Select(e => e.Description));
                return BadRequest<string>(_localizer[SharedResourceKeys.FailedToAddUser] + " : " + errors);
            }

            // assign member role
            var roleResult = await _userManager.AddToRoleAsync(user, DefaultRoles.Member);
            if (!roleResult.Succeeded)
            {
                var errors = string.Join(" ; ", roleResult.Errors.Select(e => e.Description));
                return BadRequest<string>("Failed to assign member role : " + errors);
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            await SendEmailConfirmationAsync(user, confirmationToken);


            return Success("Success", _localizer[SharedResourceKeys.UserAdded]);
        }

        private async Task SendEmailConfirmationAsync(User user, string token)
        {
            var origin = _httpContextAccessor.HttpContext?.Request.Headers.Origin.ToString();

            var confirmationLink =
                $"{origin}/auth/emailConfirmation?userId={user.Id}&code={Uri.EscapeDataString(token)}";

            var emailBody = EmailBodyBuilder.GenerateEmailBody(
                "ConfirmEmail",
                new Dictionary<string, string>
                {
                    { "{{UserName}}", user.NameEn },
                    { "{{ConfirmationLink}}", confirmationLink }
                });

            await _emailService.SendEmailAsync(
                user.Email!,
                "Confirm Your Email",
                emailBody);
        }
    }
}
