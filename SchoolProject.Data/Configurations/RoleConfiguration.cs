using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Sedding;

namespace SchoolProject.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(

           new Role
           {
               Id = DefaultRoles.AdminRoleId,
               Name = DefaultRoles.Admin,
               NormalizedName = DefaultRoles.Admin.ToUpper(),
               ConcurrencyStamp = DefaultRoles.AdminCouncurencyStamp,
               IsDeleted = false
           }

           );
        }
    }
}
