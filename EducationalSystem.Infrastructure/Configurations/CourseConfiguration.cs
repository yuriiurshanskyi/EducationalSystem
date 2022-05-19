using EducationalSystem.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalSystem.Infrastructure.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(x => x.Id);

            builder.HasMany(c => c.Registrations)
                .WithOne(r => r.Course)
                .HasForeignKey(r => r.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.CreatedBy)
                .WithMany(u => u.Courses)
                .HasForeignKey(c => c.Id);

            builder.HasOne(c => c.Category)
                .WithMany(cc => cc.Courses)
                .HasForeignKey(cc => cc.CategoryId);

        }
    }
}
