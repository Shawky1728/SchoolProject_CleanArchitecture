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
        private readonly IDepartmentService _departmentService;
        public AddStudentHandler(
            IStudentService studentService,
            IDepartmentService departmentService,
            IStringLocalizer<SharedResource> localizer) : base(localizer)
        {
            _studentService = studentService;
            _departmentService = departmentService;
        }

        public async Task<Response<AddStudentResponse>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = request.Adapt<Student>();

            var IsExist = await _studentService.IsNameExist(student.NameAr, student.NameEn);
            if (IsExist)
            {
                return BadRequest<AddStudentResponse>(_localizer[SharedResourceKeys.NameAlreadyExists])!;
            }

            // check if the department exists
            var isDepartmentExists = await _departmentService.IsDepartmentExists(student?.DID!.Value ?? 0);
            if (!isDepartmentExists)
            {
                return BadRequest<AddStudentResponse>(_localizer[SharedResourceKeys.DepartmentNotFound])!;
            }

            var result = await _studentService.AddAsync(student);


            var response = result.Adapt<AddStudentResponse>();

            return Created(response, _localizer[SharedResourceKeys.StudentAdded].Value);
        }
    }
}
