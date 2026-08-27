using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Authorization.Commands.AddRole
{
    public class AddRoleHandler : ResponseHandler, IRequestHandler<AddRoleCommand, Response<AddRoleResponse>>
    {
        private readonly IAuthorizationService _authorizationService;

        public AddRoleHandler(IStringLocalizer<SharedResource> localizer, IAuthorizationService authorizationService) : base(localizer)
        {
            _authorizationService = authorizationService;
        }

        public async Task<Response<AddRoleResponse>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _authorizationService.IsRoleExistByName(request.Name);
            if (isExist)
            {
                return BadRequest<AddRoleResponse>(_localizer[SharedResourceKeys.RoleIsExist]);
            }

            var result = await _authorizationService.AddRoleAsync(request.Name);
            if (result == "Success")
            {
                return Success(new AddRoleResponse { Name = request.Name }, _localizer[SharedResourceKeys.RoleAdded]);
            }

            return BadRequest<AddRoleResponse>(_localizer[SharedResourceKeys.AddRoleFailed]);
        }
    }
}
