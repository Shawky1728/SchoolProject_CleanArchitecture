using Mapster;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities.Views;
using SchoolProject.Infrastructure.Abstract.Views;

namespace SchoolProject.Core.Features.Departments.Queries.GetDepartmentStudentCount
{
    public class GetDepartmentStudentCountHandler : ResponseHandler, IRequestHandler<GetDepartmentStudentCountQuery, Response<PaginatedList<GetDepartmentStudentCountResponse>>>
    {
        private readonly IViewRepository _viewRepository;

        public GetDepartmentStudentCountHandler(IViewRepository viewRepository, IStringLocalizer<SharedResource> localizer) : base(localizer)
        {
            _viewRepository = viewRepository;
        }

        public async Task<Response<PaginatedList<GetDepartmentStudentCountResponse>>> Handle(GetDepartmentStudentCountQuery request, CancellationToken cancellationToken)
        {
            var query = _viewRepository.GetTableAsTracking().AsQueryable();
            var paginatedList = await PaginatedList<ViewDepartments>.CreateAsync(query, request.PageNumber, request.PageSize, cancellationToken);
            var response = paginatedList.Adapt<PaginatedList<GetDepartmentStudentCountResponse>>();
            return Success(response, "Department student count retrieved successfully");
        }
    }
}