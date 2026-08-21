using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Students.Commands.AddStudent
{
    public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
    {
        private IStringLocalizer<SharedResource> localizer;
        public AddStudentCommandValidator(IStringLocalizer<SharedResource> localizer)
        {
            this.localizer = localizer;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(localizer[SharedResourceKeys.RequiredField])
                .MaximumLength(50).WithMessage(localizer[SharedResourceKeys.NameMaxLength50]);

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(localizer[SharedResourceKeys.RequiredField])
                .MaximumLength(100).WithMessage(localizer[SharedResourceKeys.AddressMaxLength100]);

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage(localizer[SharedResourceKeys.RequiredField])
                .Matches("^\\+?\\d{10,15}$").WithMessage(localizer[SharedResourceKeys.PhoneFormat]);

        }
    }
}
