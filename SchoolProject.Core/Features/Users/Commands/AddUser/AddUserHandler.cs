using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.Users.Commands.AddUser
{
    public class AddUserHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<AddUserResponse>>
    {
        private readonly UserManager<User> _userManager;
        public AddUserHandler(IStringLocalizer<SharedResource> localizer, UserManager<User> userManager) : base(localizer)
        {
            _userManager = userManager;
        }

        public async Task<Response<AddUserResponse>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var IsEmailExist = await _userManager.FindByEmailAsync(request.Email);

            if (IsEmailExist != null)
            {
                return BadRequest<AddUserResponse>(_localizer[SharedResourceKeys.EmailExists]);
            }

            // create a new user
            var user = request.Adapt<User>();
            user.UserName = request.Email;
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return BadRequest<AddUserResponse>(_localizer[SharedResourceKeys.FailedToAddUser] + string.Join(";", result.Errors.Select(e => e.Description)));
            }
            var addUserResponse = user.Adapt<AddUserResponse>();

            return Success(addUserResponse, _localizer[SharedResourceKeys.UserAdded]);
        }
    }
}
