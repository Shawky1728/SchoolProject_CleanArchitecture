namespace SchoolProject.Data.Entities
{
    public class Instructor
    {
        public Instructor()
        {
            SupervisedInstructors = new HashSet<Instructor>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }
        public int InsId { get; set; }
        public string ENameAr { get; set; }
        public string ENameEn { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public int DID { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Department? ManagedDepartment { get; set; }

        public virtual Instructor? Supervisor { get; set; }

        public virtual ICollection<Instructor> SupervisedInstructors { get; set; } = new HashSet<Instructor>();
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }

    }
}
