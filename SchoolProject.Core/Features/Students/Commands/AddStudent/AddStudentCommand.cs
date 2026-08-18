using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;


namespace SchoolProject.Core.Features.Students.Commands.AddStudent
{
    public class AddStudentCommand:IRequest<Response<AddStudentResponse>>
    {
        public AddStudentRequest _addStudentRequest;
        public AddStudentCommand(AddStudentRequest addStudentRequest)
        {
            _addStudentRequest = addStudentRequest;
        }
    }
}
