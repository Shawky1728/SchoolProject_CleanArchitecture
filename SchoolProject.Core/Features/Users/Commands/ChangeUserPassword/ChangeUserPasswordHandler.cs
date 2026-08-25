using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.Users.Commands.ChangeUserPassword
{
    public class ChangeUserPasswordHandler : ResponseHandler, IRequestHandler<ChangeUserPasswordCommand, Response<bool>>
    {
        private readonly UserManager<User> _userManager;
        public ChangeUserPasswordHandler(IStringLocalizer<SharedResource> localizer, UserManager<User> userManager) : base(localizer)
        {
            _userManager = userManager;
        }

        public async Task<Response<bool>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.userId);
            if (user == null)
            {
                return NotFound<bool>(_localizer[SharedResourceKeys.NotFound]);
            }


            var changePasswordResult = await _userManager.ChangePasswordAsync(user, request.oldPassword, request.newPassword);

            if (!changePasswordResult.Succeeded)
            {
                return BadRequest<bool>(_localizer[SharedResourceKeys.FailedToChangePassword]);
            }

            return Success<bool>(true);
        }
    }
}
