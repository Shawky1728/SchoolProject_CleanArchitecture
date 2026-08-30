using Mapster;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Data.Entities.Procedures;
using SchoolProject.Infrastructure.Abstract.Procedures;

namespace SchoolProject.Core.Features.Departments.Queries.GetDepartmentStudentCountById
{
    public class GetDepartmentStudentCountByIdHandler : ResponseHandler, IRequestHandler<GetDepartmentStudentCountByIdQuery, Response<GetDepartmentStudentCountByIdResponse>>
    {
        private readonly IProcedures _procedures;

        public GetDepartmentStudentCountByIdHandler(IProcedures procedures, IStringLocalizer<SharedResource> localizer) : base(localizer)
        {
            _procedures = procedures;
        }

        public async Task<Response<GetDepartmentStudentCountByIdResponse>> Handle(GetDepartmentStudentCountByIdQuery request, CancellationToken cancellationToken)
        {
            var parameters = new DepartmentProcParameters
            {
                DID = request.DID
            };

            var result = await _procedures.GetDepartmentProcAsync(parameters);

            return Success(result.Adapt<GetDepartmentStudentCountByIdResponse>(), "Department student count retrieved successfully.");

        }
    }
}
