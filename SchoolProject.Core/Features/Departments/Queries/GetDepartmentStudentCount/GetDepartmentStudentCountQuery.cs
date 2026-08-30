using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Departments.Queries.GetDepartmentStudentCount
{
    public class GetDepartmentStudentCountQuery : IRequest<Response<PaginatedList<GetDepartmentStudentCountResponse>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
