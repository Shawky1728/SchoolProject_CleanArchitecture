using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstract
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentWithIncludesAsync(int id);
        Task<bool> IsDepartmentExists(int id);
    }
}
