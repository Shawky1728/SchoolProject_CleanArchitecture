using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.GenericRepository;

namespace SchoolProject.Infrastructure.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        #region Fields
        private DbSet<Subject> _subjects;
        #endregion

        #region Constructor
        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _subjects = dbContext.Set<Subject>();
        }
        #endregion


        #region Methods

        #endregion
    }
}
