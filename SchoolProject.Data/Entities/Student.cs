using SchoolProject.Data.Shared;

namespace SchoolProject.Data.Entities
{
    public class Student : LocalizableEntity
    {
        public Student()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
        }

        public int StudID { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? DID { get; set; }

        public virtual Department? Department { get; set; }
        public virtual ICollection<StudentSubject>? StudentsSubjects { get; set; }
    }
}
