using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;

namespace SchoolProject.Core.Features.Departments.Queries.GetDepartmentStudentCountById
{
    public class GetDepartmentStudentCountByIdQuery : IRequest<Response<GetDepartmentStudentCountByIdResponse>>
    {
        public int DID { get; set; }
    }
}
