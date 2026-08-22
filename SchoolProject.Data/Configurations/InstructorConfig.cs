using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Data.Configurations
{
    public class InstructorConfig : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.InsId);

            // Supervisor self-referencing relationship
            builder.HasOne(x => x.Supervisor)
                .WithMany(x => x.SupervisedInstructors)
                .HasForeignKey(x => x.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department relationship
            builder.HasOne(x => x.Department)
                .WithMany(x => x.Instructors)
                .HasForeignKey(x => x.DID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
