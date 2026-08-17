using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.GenericRepository;


namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Fields
        private readonly DbSet<Student> _students;

        #endregion

        #region Constructor
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _students = dbContext.Set<Student>();
        }
        #endregion

        #region Methods
        public async Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken = default)
        {
            return await _students.Include(s => s.Department).ToListAsync(cancellationToken);
        }


        #endregion
    }
}
