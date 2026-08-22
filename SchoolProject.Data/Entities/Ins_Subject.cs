namespace SchoolProject.Data.Entities
{
    public class Ins_Subject
    {
        public int InsId { get; set; }
        public int SubId { get; set; }
        public Instructor? Instructor { get; set; }
        public Subject? Subject { get; set; }
    }
}
