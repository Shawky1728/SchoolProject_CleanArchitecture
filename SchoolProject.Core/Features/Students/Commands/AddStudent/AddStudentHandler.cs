using Mapster;
using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Commands.AddStudent
{
    public class AddStudentHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<AddStudentResponse>>
    {
        private readonly IStudentService _studentService;
        public AddStudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<Response<AddStudentResponse>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = request.Adapt<Student>();

            var IsExist = await _studentService.IsNameExist(student.Name);
            if (IsExist)
            {
                return BadRequest<AddStudentResponse>("Name Already Exists");
            }

            var result = await _studentService.AddAsync(student);


            var response = result.Adapt<AddStudentResponse>();

            return Created(response, "Student Added Successfully");
        }
    }
}
