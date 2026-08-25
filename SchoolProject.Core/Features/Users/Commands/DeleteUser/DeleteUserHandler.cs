using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.Users.Commands.DeleteUser
{
    public class DeleteUserHandler : ResponseHandler, IRequestHandler<DeleteUserCommand, Response<string>>
    {
        private readonly UserManager<User> _userManager;

        public DeleteUserHandler(IStringLocalizer<SharedResource> localizer, UserManager<User> userManager) : base(localizer)
        {
            _userManager = userManager;
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                return NotFound<string>(_localizer[SharedResourceKeys.UserNotFound]);
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest<string>(_localizer[SharedResourceKeys.FailedToDeleteUser] + string.Join(";", result.Errors.Select(e => e.Description)));
            }

            return Success(string.Empty, _localizer[SharedResourceKeys.UserDeleted]);
        }
    }
}
