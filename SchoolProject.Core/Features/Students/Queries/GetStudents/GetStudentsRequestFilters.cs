namespace SchoolProject.Core.Features.Students.Queries.GetStudents
{
    public record GetStudentsRequestFilters(
        int PageNumber = 1,
        int PageSize = 10
        );

}
