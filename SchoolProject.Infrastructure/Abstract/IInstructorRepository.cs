using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.GenericRepository;

namespace SchoolProject.Infrastructure.Abstract
{
    public interface IInstructorRepository : IGenericRepositoryAsync<Instructor>
    {
    }
}
