using EducationalSystem.Infrastructure.Configurations;
using EducationalSystem.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace EducationalSystem.Infrastructure
{
    public class EducationContext : IdentityDbContext<UserEntity,
        RoleEntity,
        int,
        IdentityUserClaim<int>,
        UserRoleEntity,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<RegistrationEntity> Registrations { get; set; }

        public EducationContext(DbContextOptions<EducationContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new RegistrationConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
