using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Instructor
    {
        public Instructor()
        {
            SupervisedInstructors = new HashSet<Instructor>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }
        [Key]
        public int InsId { get; set; }
        public string ENameAr { get; set; }
        public string ENameEn { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public int DID { get; set; }
        [ForeignKey(nameof(DID))]
        [InverseProperty("Instructors")]
        public virtual Department? Department { get; set; }
        [InverseProperty("Manager")]
        public virtual Department? ManagedDepartment { get; set; }

        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty("SupervisedInstructors")]
        public virtual Instructor? Supervisor { get; set; }

        [InverseProperty(nameof(Supervisor))]
        public virtual ICollection<Instructor> SupervisedInstructors { get; set; } = new HashSet<Instructor>();
        [InverseProperty(nameof(Ins_Subject.Instructor))]
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }

    }
}
