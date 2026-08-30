using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Procedures;
using SchoolProject.Infrastructure.Abstract.Procedures;
using SchoolProject.Infrastructure.Data;

namespace SchoolProject.Infrastructure.Repositories.Procedures
{
    public class ProceduresRepository : IProcedures
    {
        private readonly ApplicationDbContext _db;
        public ProceduresRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<DepartmentProc> GetDepartmentProcAsync(DepartmentProcParameters parameters)
        {
            var result = await _db.DepartmentProcs
            .FromSqlInterpolated(
           $"EXEC DepartmentProc @DID={parameters.DID}")
            .ToListAsync();

            return result.FirstOrDefault();
        }


    }
}
