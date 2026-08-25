using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;

namespace SchoolProject.Core.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public Guid UserId { get; set; }
        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
