using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;


namespace SchoolProject.Core.Features.Students.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<Response<GetStudentByIdResponse>>
    {
        public int Id { get; set; }
        public GetStudentByIdQuery( int id)
        {
            Id = id;
        }
    }
}
