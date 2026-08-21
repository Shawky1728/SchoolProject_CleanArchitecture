using Mapster;
using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstract;


namespace SchoolProject.Core.Features.Students.Queries.GetStudents
{
    public class GetStudentsHandler : ResponseHandler, IRequestHandler<GetStudentsQuery, Response<PaginatedList<GetStudentsResponse>>>
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
        public async Task<Response<PaginatedList<GetStudentsResponse>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var queryableStudents = _studentService.GetAllStudentsQueryable(request.SearchTerm);
            var PaginatedData = await PaginatedList<Student>.CreateAsync(queryableStudents, request.PageNumber, request.PageSize, cancellationToken);
            var result = PaginatedData.Adapt<PaginatedList<GetStudentsResponse>>();
            return Success(result, "Students retrieved successfully.");
        }
        #endregion
    }
}
