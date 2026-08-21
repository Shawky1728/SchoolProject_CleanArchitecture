using SchoolProject.Data.Helper;

namespace SchoolProject.Core.Features.Students.Queries.GetStudents
{
    public record GetStudentsRequestFilters(
        int PageNumber = 1,
        int PageSize = 10,
        string? SearchTerm = null,
        StudentOrderEnum? OrderBy = null
        );

}
