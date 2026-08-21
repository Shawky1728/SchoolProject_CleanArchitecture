using Mapster;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentHandler : ResponseHandler, IRequestHandler<UpdateStudentCommand, Response<bool>>
    {
        private readonly IStudentService _studentService;

        public UpdateStudentHandler(IStudentService studentService, IStringLocalizer<SharedResource> localizer) : base(localizer)
        {
            _studentService = studentService;
        }

        public async Task<Response<bool>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdWithoutIncludesAsync(request.Id, cancellationToken);
            if (student == null)
            {
                return BadRequest<bool>(_localizer[SharedResourceKeys.StudentNotFound])!;
            }

            request.Adapt(student);

            var result = await _studentService.UpdateAsync(student);
            if (!result)
            {
                return BadRequest<bool>(_localizer[SharedResourceKeys.FailedToUpdateStudent])!;
            }

            return Success(true, _localizer[SharedResourceKeys.StudentUpdated].Value);
        }
    }
}
