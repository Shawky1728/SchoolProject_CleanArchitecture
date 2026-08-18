using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Core.Features.Students.Commands.AddStudent
{
    public class AddStudentResponse
    {
        public int? StudID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? DID { get; set; }
    }
}
