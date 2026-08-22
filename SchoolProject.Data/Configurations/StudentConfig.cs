using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Data.Configurations
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StudID);

            builder.Property(x => x.NameAr)
                .HasMaxLength(200);

            builder.Property(x => x.NameEn)
                .HasMaxLength(200);

            builder.Property(x => x.Address)
                .HasMaxLength(500);

            builder.Property(x => x.Phone)
                .HasMaxLength(500);

            builder.HasOne(x => x.Department)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.DID);
        }
    }
}
