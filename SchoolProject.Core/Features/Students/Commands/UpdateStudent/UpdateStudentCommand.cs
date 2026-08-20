using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;

namespace SchoolProject.Core.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? DepartmentId { get; set; }
    }
}
