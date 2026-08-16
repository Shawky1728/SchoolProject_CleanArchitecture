using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Abstract
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken = default);
    }
}
