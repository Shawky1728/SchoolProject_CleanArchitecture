using Mapster;
using MediatR;
using SchoolProject.Core.Features.Students.Queries.GetStudents;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Service.Abstract;


namespace SchoolProject.Core.Features.Students.Queries.GetStudentById
{
    public class GetStudentByIdHandler : ResponseHandler, IRequestHandler<GetStudentByIdQuery, Response<GetStudentByIdResponse>>
    {
        private readonly IStudentService _studentService;

        public GetStudentByIdHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<Response<GetStudentByIdResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id, cancellationToken);

            if(student == null)
            {
                return NotFound<GetStudentByIdResponse>("Student not found.")!;
            }

            var response = student.Adapt<GetStudentByIdResponse>();

            return Success(response, "Student retrieved successfully.");

        }
    }
}
