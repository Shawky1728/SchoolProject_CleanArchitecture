using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Helper;


namespace SchoolProject.Core.Features.Students.Queries.GetStudents
{
    public record GetStudentsQuery : IRequest<Response<PaginatedList<GetStudentsResponse>>>
    {
        public GetStudentsQuery(int pageNumber = 1, int pageSize = 10, string? searchTerm = null, StudentOrderEnum? orderById = null)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchTerm = searchTerm;
            OrderBy = orderById;
        }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public string? SearchTerm { get; init; }
        public StudentOrderEnum? OrderBy { get; init; }
    }
}
