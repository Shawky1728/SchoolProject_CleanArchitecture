using SchoolProject.Data.Entities;


namespace SchoolProject.Service.Abstract
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken = default);
        Task<Student?> GetStudentByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
