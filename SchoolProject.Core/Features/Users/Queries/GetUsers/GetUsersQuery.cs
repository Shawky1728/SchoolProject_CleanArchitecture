using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<Response<PaginatedList<UserResponse>>>
    {
        public GetUsersQuery(int pageNumber, int pageSize, string searchTerm)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchTerm = searchTerm;
        }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SearchTerm { get; set; } = string.Empty;

    }
}
