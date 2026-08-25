using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : ResponseHandler, IRequestHandler<UpdateUserCommand, Response<string>>
    {
        private readonly UserManager<User> _userManager;
        public UpdateUserHandler(IStringLocalizer<SharedResource> localizer, UserManager<User> userManager) : base(localizer)
        {
            _userManager = userManager;
        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                return NotFound<string>(_localizer[SharedResourceKeys.UserNotFound]);
            }



            // map values to existing user
            user.NameAr = request.NameAr;
            user.NameEn = request.NameEn;
            user.Address = request.Address;
            user.PhoneNumber = request.PhoneNumber;
            user.City = request.City;
            user.Country = request.Country;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest<string>(_localizer[SharedResourceKeys.FailedToUpdateUser] + string.Join(";", result.Errors.Select(e => e.Description)));
            }

            return Success(string.Empty, _localizer[SharedResourceKeys.UserUpdated]);
        }
    }
}
