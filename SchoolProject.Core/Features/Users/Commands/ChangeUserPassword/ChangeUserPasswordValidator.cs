using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Users.Commands.ChangeUserPassword
{
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        public ChangeUserPasswordValidator(IStringLocalizer<SharedResource> localizer)
        {
            RuleFor(x => x.userId)
                .NotEmpty().WithMessage(localizer[SharedResourceKeys.RequiredField]);

            RuleFor(x => x.oldPassword)
                .NotEmpty().WithMessage(localizer[SharedResourceKeys.RequiredField]);

            RuleFor(x => x.newPassword)
                .NotEmpty()
                .WithMessage(localizer[SharedResourceKeys.RequiredField])
                .MinimumLength(8).WithMessage(localizer[SharedResourceKeys.PasswordComplexity]);

        }
    }
}
