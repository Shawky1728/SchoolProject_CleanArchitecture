using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Authorization;
using SchoolProject.Data.Sedding;

namespace SchoolProject.Data.Configurations
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
        {
            var permissions = Permissions.GetAllPermissions();

            var adminRoleClaims = new List<IdentityRoleClaim<string>>();

            for (int i = 0; i < permissions.Count; i++)
            {
                adminRoleClaims.Add(new IdentityRoleClaim<string>
                {
                    Id = i + 1,
                    ClaimType = Permissions.Type,
                    ClaimValue = permissions[i],
                    RoleId = DefaultRoles.AdminRoleId
                });
            }

            builder.HasData(adminRoleClaims);
        }
    }
}
