using EducationalSystem.Infrastructure;
using EducationalSystem.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace EducationalSystem.Helpers
{
    public static class SeedData
    {
        public static async Task InitializeAsync(EducationContext context,
            UserManager<UserEntity> userManager,
            RoleManager<RoleEntity> roleManager)
        {


            var admin = new UserEntity
            {
                Name = "Admin",
                UserName = "Admin",
                Email = "admin@example.com",
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            await userManager.CreateAsync(admin, "Admin123@");

            var superAdmin = new RoleEntity
            {
                Name = "SuperAdmin",
            };

            var result = await roleManager.CreateAsync(superAdmin);
            await userManager.AddToRoleAsync(admin, superAdmin.Name);

            var provider = new RoleEntity
            {
                Name = "Provider"
            };

            await roleManager.CreateAsync(provider);

            var registeredUser = new RoleEntity
            {
                Name = "RegisteredUser"
            };

            await roleManager.CreateAsync(registeredUser);



        }

        public static async Task InitializeCategoriesAsync(EducationContext context)
        {
            context.Categories.AddRange(new List<CategoryEntity>
                {
                    new()
                    {
                        Name = "Physics"
                    },
                    new()
                    {
                        Name = "Math"
                    },
                    new()
                    {
                        Name = "Ukrainian language"
                    },
                    new()
                    {
                        Name = "Ukrainian literature"
                    },
                    new()
                    {
                        Name = "English"
                    },
                    new()
                    {
                        Name = "Chemistry"
                    },
                    new()
                    {
                        Name = "German"
                    }
                });

            await context.SaveChangesAsync();
        }
    }
}
