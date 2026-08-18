

namespace SchoolProject.Core.Features.Students.Commands.AddStudent
{
    public class AddStudentRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string DepartmentId { get; set; }
    }
}
