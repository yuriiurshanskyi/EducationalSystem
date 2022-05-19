using EducationalSystem.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalSystem.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.HasMany(c => c.Courses)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);
        }
    }
}
