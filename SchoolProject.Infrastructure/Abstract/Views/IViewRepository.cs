using SchoolProject.Data.Entities.Views;
using SchoolProject.Infrastructure.GenericRepository;

namespace SchoolProject.Infrastructure.Abstract.Views
{
    public interface IViewRepository : IGenericRepositoryAsync<ViewDepartments>
    {
    }
}
