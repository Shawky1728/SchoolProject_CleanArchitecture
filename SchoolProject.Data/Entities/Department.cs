using SchoolProject.Data.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        public int DID { get; set; }
        [StringLength(500)]
        public string DNameAr { get; set; }
        [StringLength(500)]
        public string DNameEn { get; set; }
        public int? ManagerId { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<Instructor> Instructors { get; set; }
        [ForeignKey(nameof(ManagerId))]
        [InverseProperty("ManagedDepartment")]
        public virtual Instructor? Manager { get; set; }
    }
}
