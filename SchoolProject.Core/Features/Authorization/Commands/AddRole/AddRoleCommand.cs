using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;

namespace SchoolProject.Core.Features.Authorization.Commands.AddRole
{
    public class AddRoleCommand : IRequest<Response<AddRoleResponse>>
    {
        public string Name { get; set; }
    }
}
