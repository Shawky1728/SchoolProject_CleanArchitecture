using Microsoft.EntityFrameworkCore;

namespace SchoolProject.Data.Entities.Procedures
{
    [Keyless]
    public class DepartmentProc
    {
        public int DID { get; set; }
        public string? DNameAr { get; set; }
        public string? DNameEn { get; set; }
        public int studentCount { get; set; }
    }

    public class DepartmentProcParameters
    {
        public int DID { get; set; } = 1;
    }
}
