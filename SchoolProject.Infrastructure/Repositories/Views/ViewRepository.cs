using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Views;
using SchoolProject.Infrastructure.Abstract.Views;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.GenericRepository;

namespace SchoolProject.Infrastructure.Repositories.Views
{
    public class ViewRepository : GenericRepositoryAsync<ViewDepartments>, IViewRepository
    {
        private readonly DbSet<ViewDepartments> _viewDepartments;
        public ViewRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _viewDepartments = dbContext.Set<ViewDepartments>();
        }
    }
}
