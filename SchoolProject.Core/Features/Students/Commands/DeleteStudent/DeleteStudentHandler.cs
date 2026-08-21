using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentHandler : ResponseHandler, IRequestHandler<DeleteStudentCommand, Response<bool>>
    {
        private readonly IStudentService _studentService;

        public DeleteStudentHandler(IStudentService studentService, IStringLocalizer<SharedResource> localizer) : base(localizer)
        {
            _studentService = studentService;
        }
        public async Task<Response<bool>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdWithoutIncludesAsync(request.Id, cancellationToken);

            if (student == null)
            {

                return NotFound<bool>(_localizer[SharedResourceKeys.StudentNotFound])!;
            }
            var result = await _studentService.DeleteAsync(student, cancellationToken);
            if (result)
            {
                return Success(true, _localizer[SharedResourceKeys.StudentDeleted].Value);
            }
            return BadRequest<bool>(_localizer[SharedResourceKeys.FailedToDeleteStudent])!;
        }
    }
}
