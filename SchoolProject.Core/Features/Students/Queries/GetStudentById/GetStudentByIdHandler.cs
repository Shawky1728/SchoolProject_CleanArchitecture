using Mapster;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Queries.GetStudents;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Service.Abstract;


namespace SchoolProject.Core.Features.Students.Queries.GetStudentById
{
    public class GetStudentByIdHandler : ResponseHandler, IRequestHandler<GetStudentByIdQuery, Response<GetStudentByIdResponse>>
    {
        private readonly IStudentService _studentService;

        public GetStudentByIdHandler(IStudentService studentService, IStringLocalizer<SharedResource> localizer) : base(localizer)
        {
            _studentService = studentService;
        }

        public async Task<Response<GetStudentByIdResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id, cancellationToken);

            if(student == null)
            {
                return NotFound<GetStudentByIdResponse>(_localizer[SharedResourceKeys.StudentNotFound])!;
            }

            var response = student.Adapt<GetStudentByIdResponse>();

            return Success(response, _localizer[SharedResourceKeys.StudentRetrieved].Value);

        }
    }
}
