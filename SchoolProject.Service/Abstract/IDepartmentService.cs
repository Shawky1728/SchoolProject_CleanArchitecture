using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstract
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentWithIncludesAsync(int id);
    }
}
