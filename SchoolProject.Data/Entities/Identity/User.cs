using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Data.Entities.Identity
{
    public class User : IdentityUser
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();

    }
}
