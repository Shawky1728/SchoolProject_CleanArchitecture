using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Infrastructure.Data;


namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        #region Fields
        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructor
        public StudentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Methods
        public async Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Students.ToListAsync(cancellationToken);
        }


        #endregion
    }
}
