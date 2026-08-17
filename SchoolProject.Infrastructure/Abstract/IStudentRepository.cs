using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.GenericRepository;

namespace SchoolProject.Infrastructure.Abstract
{
    public interface IStudentRepository:IGenericRepositoryAsync<Student>
    {
        Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken = default);
    }
}
