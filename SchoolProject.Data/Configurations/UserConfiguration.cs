using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Sedding;

namespace SchoolProject.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                Id = DefaultUsers.AdminId,
                NameAr = "مدير النظام",
                NameEn = "System Administrator",
                UserName = DefaultUsers.AdminEmail,
                NormalizedUserName = DefaultUsers.AdminEmail.ToUpper(),
                Email = DefaultUsers.AdminEmail,
                NormalizedEmail = DefaultUsers.AdminEmail.ToUpper(),
                SecurityStamp = DefaultUsers.AdminSecurityStamp,
                ConcurrencyStamp = DefaultUsers.AdminConcurrencyStamp,
                EmailConfirmed = true,
                PasswordHash = DefaultUsers.AdminPasswordHash

            },
            new User
            {
                Id = DefaultUsers.MemberId,
                NameAr = "عضو النظام",
                NameEn = "System Member",
                UserName = DefaultUsers.MemberEmail,
                NormalizedUserName = DefaultUsers.MemberEmail.ToUpper(),
                Email = DefaultUsers.MemberEmail,
                NormalizedEmail = DefaultUsers.MemberEmail.ToUpper(),
                SecurityStamp = DefaultUsers.MemberSecurityStamp,
                ConcurrencyStamp = DefaultUsers.MemberConcurrencyStamp,
                EmailConfirmed = true,
                PasswordHash = DefaultUsers.MemberPasswordHash
            }
            );
        }
    }
}
