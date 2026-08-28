using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Authorization.Commands.DeleteRole
{
    public class DeleteRoleHandler : ResponseHandler, IRequestHandler<DeleteRoleCommand, Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;

        public DeleteRoleHandler(IStringLocalizer<SharedResource> localizer, IAuthorizationService authorizationService) : base(localizer)
        {
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.DeleteRoleAsync(request.Id);
            if (result == "notFound")
            {
                return NotFound<string>(_localizer[SharedResourceKeys.RoleNotExist]);
            }
            if (result == "Success")
            {
                return Success(string.Empty, _localizer[SharedResourceKeys.RoleDeleted]);
            }

            return BadRequest<string>(_localizer[SharedResourceKeys.DeleteRoleFailed]);
        }
    }
}
