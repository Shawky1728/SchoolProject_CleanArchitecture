using MediatR;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstract;


namespace SchoolProject.Core.Features.Students.Queries.GetStudents
{
    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, List<Student>>
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
        public async Task<List<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetAllStudentsAsync();
        }
        #endregion
    }
}
