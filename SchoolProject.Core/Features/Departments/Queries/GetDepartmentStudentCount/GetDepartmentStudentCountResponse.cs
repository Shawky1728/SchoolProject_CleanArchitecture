namespace SchoolProject.Core.Features.Departments.Queries.GetDepartmentStudentCount
{
    public class GetDepartmentStudentCountResponse
    {
        public int DID { get; set; }
        public string? DNameAr { get; set; }
        public string? DNameEn { get; set; }
        public int studentCount { get; set; }
    }
}
