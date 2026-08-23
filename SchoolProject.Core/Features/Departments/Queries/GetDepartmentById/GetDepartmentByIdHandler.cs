using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdHandler : ResponseHandler, IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        private readonly IDepartmentService _departmentService;

        public GetDepartmentByIdHandler(IDepartmentService departmentService, IStringLocalizer<SharedResource> localizer) : base(localizer)
        {
            _departmentService = departmentService;
        }
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetDepartmentWithIncludesAsync(request.Id);

            if (department == null)
            {
                return NotFound<GetDepartmentByIdResponse>(_localizer[SharedResourceKeys.DepartmentNotFound]);
            }

            var getDepartmentByIdResponse = new GetDepartmentByIdResponse
            {
                Id = department.DID,
                Name = department.GetLocalizedValue(department.DNameAr, department.DNameEn),
                MangerName = department.GetLocalizedValue(department?.Manager?.ENameAr, department?.Manager?.ENameEn),
                Students = department.Students?.Select(s => new StudentResponse
                {
                    Id = s.StudID,
                    Name = s.GetLocalizedValue(s.NameAr, s.NameEn),

                }).ToList(),
                Subjects = department.DepartmentSubjects?.Select(s => new SubjectResponse
                {
                    Id = s.SubID,
                    Name = s.Subject?.GetLocalizedValue(s.Subject.SubjectNameAr, s.Subject.SubjectNameEn)!

                }).ToList(),
                Instructors = department.Instructors?.Select(i => new InstructorResponse
                {
                    Id = i.InsId,
                    Name = i.GetLocalizedValue(i.ENameAr, i.ENameEn),
                }).ToList()
            };

            return Success(getDepartmentByIdResponse, _localizer[SharedResourceKeys.DepartmentRetrieved]);

        }
    }
}
