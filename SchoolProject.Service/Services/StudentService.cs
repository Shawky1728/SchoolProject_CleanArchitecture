using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helper;
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
            var IsExist = await _studentRepository.GetTableNoTracking().Where(i => i.NameEn == name).FirstOrDefaultAsync();
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

        public IQueryable<Student> GetAllStudentsQueryable(string? searchTerm = null, StudentOrderEnum? orderBy = null)
        {
            var students = _studentRepository.GetTableNoTracking().Include(i => i.Department).AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                students = students.Where(s => s.NameEn.Contains(searchTerm));
            }

            if (orderBy.HasValue)
            {
                switch (orderBy.Value)
                {
                    case StudentOrderEnum.Id:
                        students = students.OrderBy(s => s.StudID);
                        break;
                    case StudentOrderEnum.Name:
                        students = students.OrderBy(s => s.GetLocalizedValue(s.NameAr, s.NameEn));
                        break;
                    case StudentOrderEnum.Address:
                        students = students.OrderBy(s => s.Address);
                        break;
                    case StudentOrderEnum.DepartmentName:
                        students = students.OrderBy(s => s.GetLocalizedValue(s.Department.DNameAr, s.Department.DNameEn));
                        break;
                }
            }

            return students;
        }

        #endregion
    }
}
