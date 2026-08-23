using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<Department> GetDepartmentWithIncludesAsync(int id)
        {
            var department = await _departmentRepository.GetTableAsTracking()
                .Include(d => d.Students)
                .Include(d => d.Manager)
                .Include(d => d.DepartmentSubjects)
                .ThenInclude(ds => ds.Subject)
                .Include(d => d.Instructors)
                .Where(d => d.DID == id)
                .FirstOrDefaultAsync();

            return department!;
        }
    }
}
