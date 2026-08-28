using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Authorization.Commands.EditRole
{
    public class EditRoleHandler : ResponseHandler, IRequestHandler<EditRoleCommand, Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;

        public EditRoleHandler(IStringLocalizer<SharedResource> localizer, IAuthorizationService authorizationService) : base(localizer)
        {
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.EditRoleAsync(request.Id, request.Name);
            if (result == "notFound")
            {
                return NotFound<string>(_localizer[SharedResourceKeys.RoleNotExist]);
            }
            if (result == "isExist")
            {
                return BadRequest<string>(_localizer[SharedResourceKeys.RoleIsExist]);
            }
            if (result == "Success")
            {
                return Success(string.Empty, _localizer[SharedResourceKeys.RoleUpdated]);
            }

            return BadRequest<string>(_localizer[SharedResourceKeys.EditRoleFailed]);
        }
    }
}
