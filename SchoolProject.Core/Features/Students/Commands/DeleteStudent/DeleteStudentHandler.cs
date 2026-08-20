using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentHandler : ResponseHandler, IRequestHandler<DeleteStudentCommand, Response<bool>>
    {
        private readonly IStudentService _studentService;

        public DeleteStudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<Response<bool>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id, cancellationToken);

            if (student == null)
            {

                return NotFound<bool>("Student not found.");
            }
            var result = await _studentService.DeleteAsync(student, cancellationToken);
            if (result)
            {
                return Success(true, "Student deleted successfully.");
            }
            return BadRequest<bool>("Failed to delete student.");
        }
    }
}
