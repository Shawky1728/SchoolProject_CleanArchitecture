using SchoolProject.Data.Shared;

namespace SchoolProject.Data.Entities
{
    public class Subject : LocalizableEntity
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmetsSubjects = new HashSet<DepartmetSubject>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }
        public int SubID { get; set; }
        public string SubjectNameAr { get; set; }
        public string SubjectNameEn { get; set; }
        public DateTime Period { get; set; }
        public virtual ICollection<StudentSubject>? StudentsSubjects { get; set; }
        public virtual ICollection<DepartmetSubject>? DepartmetsSubjects { get; set; }
        public virtual ICollection<Ins_Subject>? Ins_Subjects { get; set; }

    }
}