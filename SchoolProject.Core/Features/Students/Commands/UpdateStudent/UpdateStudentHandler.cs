using Mapster;
using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentHandler : ResponseHandler, IRequestHandler<UpdateStudentCommand, Response<bool>>
    {
        private readonly IStudentService _studentService;

        public UpdateStudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<Response<bool>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student == null)
            {
                return BadRequest<bool>("Student not found");
            }

            request.Adapt(student);

            var result = await _studentService.UpdateAsync(student);
            if (!result)
            {
                return BadRequest<bool>("Failed to update student");
            }

            return Success(true, "Student updated successfully");
        }
    }
}
