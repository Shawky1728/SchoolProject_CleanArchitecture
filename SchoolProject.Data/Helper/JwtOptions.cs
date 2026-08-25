namespace SchoolProject.Data.Helper
{
    public class JwtOptions
    {
        public static string SectionName = "JwtSettings"; // section Name
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiresIn { get; set; }
    }
}
