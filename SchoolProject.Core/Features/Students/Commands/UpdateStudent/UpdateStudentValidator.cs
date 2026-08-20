using FluentValidation;

namespace SchoolProject.Core.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50)
                .WithMessage("Name must not exceed 50 characters.")
                .When(x => x.Name != null);

            RuleFor(x => x.Address)
                .MaximumLength(100)
                .WithMessage("Address must not exceed 100 characters.")
                .When(x => x.Address != null);

            RuleFor(x => x.Phone)
                .MaximumLength(20)
                .WithMessage("Phone must not exceed 20 characters.")
                .When(x => x.Phone != null);

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0)
                .WithMessage("DepartmentId must be greater than 0.")
                .When(x => x.DepartmentId.HasValue);
        }
    }
}
