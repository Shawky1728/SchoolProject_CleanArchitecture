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

        public async Task<Student> AddAsync(Student student)
        {
            // check if name exist

            var IsExist = _studentRepository.GetTableNoTracking().Where(i => i.Name == student.Name).FirstOrDefault();
            if (IsExist is not null)
            {
                return null;
            }

            // check department

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

        #endregion
    }
}
