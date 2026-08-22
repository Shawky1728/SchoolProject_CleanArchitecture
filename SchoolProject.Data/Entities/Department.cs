using SchoolProject.Data.Shared;

namespace SchoolProject.Data.Entities
{
    public partial class Department : LocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
            Instructors = new HashSet<Instructor>();
        }
        public int DID { get; set; }
        public string DNameAr { get; set; }
        public string DNameEn { get; set; }
        public int? ManagerId { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual Instructor? Manager { get; set; }
    }
}
