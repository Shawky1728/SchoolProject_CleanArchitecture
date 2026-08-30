namespace SchoolProject.Core.Features.Departments.Queries.GetDepartmentStudentCountById
{
    public class GetDepartmentStudentCountByIdResponse
    {
        public int DID { get; set; }
        public string? DNameAr { get; set; }
        public string? DNameEn { get; set; }
        public int studentCount { get; set; }
    }
}
