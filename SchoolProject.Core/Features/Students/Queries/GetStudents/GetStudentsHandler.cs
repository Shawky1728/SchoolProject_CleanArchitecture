using Mapster;
using MediatR;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstract;


namespace SchoolProject.Core.Features.Students.Queries.GetStudents
{
    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, List<GetStudentsResponse>>
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
        public async Task<List<GetStudentsResponse>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetAllStudentsAsync();
            var response = students.Adapt<List<GetStudentsResponse>>();
            return response;
        }
        #endregion
    }
}
