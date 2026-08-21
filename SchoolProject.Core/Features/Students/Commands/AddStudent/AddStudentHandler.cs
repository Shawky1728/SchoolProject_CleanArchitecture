using Mapster;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Commands.AddStudent
{
    public class AddStudentHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<AddStudentResponse>>
    {
        private readonly IStudentService _studentService;
        public AddStudentHandler(IStudentService studentService, IStringLocalizer<SharedResource> localizer) : base(localizer)
        {
            _studentService = studentService;
        }

        public async Task<Response<AddStudentResponse>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = request.Adapt<Student>();

            var IsExist = await _studentService.IsNameExist(student.Name);
            if (IsExist)
            {
                return BadRequest<AddStudentResponse>(_localizer[SharedResourceKeys.NameAlreadyExists])!;
            }

            // check if the department exists

            var result = await _studentService.AddAsync(student);


            var response = result.Adapt<AddStudentResponse>();

            return Created(response, _localizer[SharedResourceKeys.StudentAdded].Value);
        }
    }
}
