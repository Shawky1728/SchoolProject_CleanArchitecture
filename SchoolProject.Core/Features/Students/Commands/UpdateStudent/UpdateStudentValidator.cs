using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentValidator(IStringLocalizer<SharedResource> localizer)
        {
            RuleFor(x => x.NameAr)
                .MaximumLength(50)
                .WithMessage(localizer[SharedResourceKeys.NameMaxLength50])
                .When(x => x.NameAr != null);

            RuleFor(x => x.NameEn)
                .MaximumLength(50)
                .WithMessage(localizer[SharedResourceKeys.NameMaxLength50])
                .When(x => x.NameEn != null);

            RuleFor(x => x.Address)
                .MaximumLength(100)
                .WithMessage(localizer[SharedResourceKeys.AddressMaxLength100])
                .When(x => x.Address != null);

            RuleFor(x => x.Phone)
               .Matches("^\\+?\\d{10,15}$")
                .WithMessage(localizer[SharedResourceKeys.PhoneFormat])
                .When(x => x.Phone != null);

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0)
                .WithMessage(localizer[SharedResourceKeys.DepartmentIdRange])
                .When(x => x.DepartmentId.HasValue);
        }
    }
}
