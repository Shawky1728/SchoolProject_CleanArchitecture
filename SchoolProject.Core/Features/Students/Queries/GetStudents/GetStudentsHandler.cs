using Mapster;
using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstract;


namespace SchoolProject.Core.Features.Students.Queries.GetStudents
{
    public class GetStudentsHandler :ResponseHandler, IRequestHandler<GetStudentsQuery, Response<List<GetStudentsResponse>>>
    {
        #region Fields
        private readonly IStudentService _studentService;

        #endregion

        #region constructor
        public GetStudentsHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        #endregion

        #region Methods
        public async Task<Response<List<GetStudentsResponse>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetAllStudentsAsync();
            var response = students.Adapt<List<GetStudentsResponse>>();
            return Success(response, "Students retrieved successfully.");
        }
        #endregion
    }
}
