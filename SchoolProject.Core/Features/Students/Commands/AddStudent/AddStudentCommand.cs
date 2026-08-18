using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;


namespace SchoolProject.Core.Features.Students.Commands.AddStudent
{
    public class AddStudentCommand : IRequest<Response<AddStudentResponse>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string DepartmentId { get; set; }
    }
}
