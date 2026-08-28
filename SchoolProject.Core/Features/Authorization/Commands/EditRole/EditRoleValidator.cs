using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Authorization.Commands.EditRole
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        private readonly IStringLocalizer<SharedResource> _localizer;
        public EditRoleValidator(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(_localizer[SharedResourceKeys.RequiredField]);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(_localizer[SharedResourceKeys.RequiredField]);
        }
    }
}
