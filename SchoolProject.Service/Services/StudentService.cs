using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Service.Abstract;


namespace SchoolProject.Service.Services
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Constructor
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        #endregion

        #region Methods
        public Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken = default)
        {
            return _studentRepository.GetAllStudentsAsync(cancellationToken);

        }

        public async Task<Student?> GetStudentByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _studentRepository.GetTableNoTracking()
                                     .Include(i => i.Department)
                                     .Where(s => s.StudID == id)
                                     .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Student?> GetStudentByIdWithoutIncludesAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _studentRepository.GetTableNoTracking()
                                     .Where(s => s.StudID == id)
                                     .FirstOrDefaultAsync(cancellationToken);
        }


        public async Task<Student> AddAsync(Student student)
        {
            await _studentRepository.AddAsync(student);

            return student;

        }

        public async Task<bool> UpdateAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return true;
        }

        public async Task<bool> IsNameExist(string name)
        {
            var IsExist = await _studentRepository.GetTableNoTracking().Where(i => i.Name == name).FirstOrDefaultAsync();
            if (IsExist is not null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(Student student, CancellationToken cancellationToken = default)
        {
            var transaction = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public IQueryable<Student> GetAllStudentsQueryable()
        {
            var students = _studentRepository.GetTableNoTracking().Include(i => i.Department).AsQueryable();
            return students;
        }

        #endregion
    }
}
