using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Data.Configurations
{
    public class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.SubID);

            builder.Property(x => x.SubjectNameAr)
                .HasMaxLength(500);

            builder.Property(x => x.SubjectNameEn)
                .HasMaxLength(500);
        }
    }
}
