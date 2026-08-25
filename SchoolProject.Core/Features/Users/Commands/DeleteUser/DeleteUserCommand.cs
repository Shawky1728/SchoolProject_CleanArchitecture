using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;

namespace SchoolProject.Core.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }

        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
