using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;

namespace SchoolProject.Core.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }

        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
