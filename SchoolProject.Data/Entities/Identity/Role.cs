using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Data.Entities.Identity
{
    public class Role : IdentityRole
    {
        public bool IsDeleted { get; set; } = false;
    }
}
