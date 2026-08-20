using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Core.Wrappers;


namespace SchoolProject.Core.Features.Students.Queries.GetStudents
{
    public record GetStudentsQuery : IRequest<Response<PaginatedList<GetStudentsResponse>>>
    {
        public GetStudentsQuery(int pageNumber = 1, int pageSize = 10)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }
}
