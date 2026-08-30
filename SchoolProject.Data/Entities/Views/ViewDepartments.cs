using Microsoft.EntityFrameworkCore;

namespace SchoolProject.Data.Entities.Views
{
    [Keyless]
    public class ViewDepartments
    {
        public int DID { get; set; }
        public string? DNameAr { get; set; }
        public string? DNameEn { get; set; }
        public int studentCount { get; set; }
    }
}
