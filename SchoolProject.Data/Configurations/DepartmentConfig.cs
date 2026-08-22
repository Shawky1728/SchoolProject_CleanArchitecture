using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Data.Configurations
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.DID);

            builder.Property(x => x.DNameAr)
                .HasMaxLength(500);

            builder.Property(x => x.DNameEn)
                .HasMaxLength(500);

            builder.HasOne(x => x.Manager)
                .WithOne(x => x.ManagedDepartment)
                .HasForeignKey<Department>(x => x.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
