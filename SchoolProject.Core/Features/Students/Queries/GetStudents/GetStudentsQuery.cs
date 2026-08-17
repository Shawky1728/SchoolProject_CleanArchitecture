using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;


namespace SchoolProject.Core.Features.Students.Queries.GetStudents
{
    public class GetStudentsQuery:IRequest<Response<List<GetStudentsResponse>>>
    {
        
    }
}
