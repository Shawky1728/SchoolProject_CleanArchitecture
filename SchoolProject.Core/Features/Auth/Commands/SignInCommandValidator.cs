using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Auth.Commands
{
    public class SignInCommandValidator : AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator(IStringLocalizer<SharedResource> localizer)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(localizer[SharedResourceKeys.RequiredField])
                .EmailAddress()
                .WithMessage(localizer[SharedResourceKeys.InvalidEmailFormat]);



            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(localizer[SharedResourceKeys.RequiredField])
                .MinimumLength(8)
                .WithMessage(localizer[SharedResourceKeys.PasswordComplexity]);
        }
    }
}
