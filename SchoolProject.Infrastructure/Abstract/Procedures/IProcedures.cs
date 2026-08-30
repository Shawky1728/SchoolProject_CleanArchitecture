using SchoolProject.Data.Entities.Procedures;

namespace SchoolProject.Infrastructure.Abstract.Procedures
{
    public interface IProcedures
    {
        Task<DepartmentProc> GetDepartmentProcAsync(DepartmentProcParameters parameters);
    }
}
