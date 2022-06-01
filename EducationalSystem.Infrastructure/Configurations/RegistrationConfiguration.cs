using EducationalSystem.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalSystem.Infrastructure.Configurations
{
    public class RegistrationConfiguration : IEntityTypeConfiguration<RegistrationEntity>
    {
        public void Configure(EntityTypeBuilder<RegistrationEntity> builder)
        {
            builder.ToTable("Registrations");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Registree)
                .WithMany(u => u.Registrations)
                .HasForeignKey(r => r.RegistreeId);

            builder.HasOne(x => x.Course)
                .WithMany(c => c.Registrations)
                .HasForeignKey(r => r.CourseId);
        }
    }
}
