using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;

namespace SchoolProject.Core.Features.Authorization.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }

        public DeleteRoleCommand()
        {
        }

        public DeleteRoleCommand(string id)
        {
            Id = id;
        }
    }
}
