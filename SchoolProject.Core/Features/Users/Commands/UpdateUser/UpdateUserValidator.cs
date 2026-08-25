using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Users.Commands.UpdateUser
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IStringLocalizer<SharedResource> _localizer;
        public UpdateUserValidator(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(_localizer[SharedResourceKeys.RequiredField]);

            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage(_localizer[SharedResourceKeys.RequiredField])
                .MaximumLength(50).WithMessage(_localizer[SharedResourceKeys.NameMaxLength50]);

            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage(_localizer[SharedResourceKeys.RequiredField])
                .MaximumLength(500).WithMessage(_localizer[SharedResourceKeys.NameMaxLength50]);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_localizer[SharedResourceKeys.RequiredField])
                .EmailAddress().WithMessage(_localizer[SharedResourceKeys.InvalidEmailFormat]);

            RuleFor(x => x.Address)
                .MaximumLength(100).WithMessage(_localizer[SharedResourceKeys.AddressMaxLength100]);

            RuleFor(x => x.City)
                .MaximumLength(50).WithMessage(_localizer[SharedResourceKeys.CityMaxLength50]);

            RuleFor(x => x.Country)
                .MaximumLength(50).WithMessage(_localizer[SharedResourceKeys.CountryMaxLength50]);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage(_localizer[SharedResourceKeys.RequiredField])
                .Matches("^\\+?\\d{10,15}$").WithMessage(_localizer[SharedResourceKeys.PhoneFormat]);
        }
    }
}
