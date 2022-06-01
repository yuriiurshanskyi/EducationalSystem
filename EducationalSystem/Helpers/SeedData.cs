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

        public static async Task InitializeDbAsync(EducationContext context)
        {
            if(!context.Categories.Any())
            {
                context.Categories.AddRange(new List<CategoryEntity>
                {
                    new()
                    {
                        Name = "Інформаційні технології",
                        CategoryCode = 12
                    },
                    new()
                    {
                        Name = "Аграрні науки та продовольство",
                        CategoryCode = 20
                    },
                    new()
                    {
                        Name = "Автоматизація та приладобудування",
                        CategoryCode = 15
                    },
                    new()
                    {
                        Name = "Механічна інженерія",
                        CategoryCode = 13
                    },
                    new()
                    {
                        Name = "Транспорт",
                        CategoryCode = 27
                    },
                    new()
                    {
                        Name = "Архітектура та будівництво",
                        CategoryCode = 19
                    },
                    new()
                    {
                        Name = "Електроніка та телекомунікації",
                        CategoryCode = 17
                    }
                });
            }

            if (!context.Courses.Any())
            {
                context.Courses.AddRange(new List<CourseEntity>
                {
                    new()
                    {
                        Title = "Розвиток м’яких навичок для викладачів комп’ютерних наук",
                        Ects = 60,
                        BeginsAt = new DateTime(2022,9,1),
                        EndAt = new DateTime(2023,1,1),
                        CategoryId = 1,
                        CreatorId = 1,
                        Description = "Very interesing course",
                        CreatedDate = DateTimeOffset.Now,
                        CourseType = Infrastructure.Enums.CourseTypes.CourseType.Offline
                    },
                    new()
                    {
                        Title = "Програми функціонального тестування програмного забезпечення онлайн",
                        Ects = 90,
                        BeginsAt = new DateTime(2022,11,12),
                        EndAt = new DateTime(2023,3,12),
                        CategoryId = 1,
                        CreatorId = 1,
                        Description = "Very interesing course",
                        CreatedDate = DateTimeOffset.Now,
                        CourseType = Infrastructure.Enums.CourseTypes.CourseType.Offline
                    },
                    new()
                    {
                        Title = "Онлайн програма DevOps",
                        Ects = 30,
                        BeginsAt = new DateTime(2022,8,10),
                        EndAt = new DateTime(2022,12,10),
                        CategoryId = 1,
                        CreatorId = 1,
                        Description = "Very interesing course",
                        CreatedDate = DateTimeOffset.Now,
                        CourseType = Infrastructure.Enums.CourseTypes.CourseType.Offline
                    },
                    new()
                    {
                        Title = "Онлайн-програма аналізу ефективності",
                        Ects = 120,
                        BeginsAt = new DateTime(2022,7, 15),
                        EndAt = new DateTime(2022,12,15),
                        CategoryId = 1,
                        CreatorId = 1,
                        Description = "Very interesing course",
                        CreatedDate = DateTimeOffset.Now,
                        CourseType = Infrastructure.Enums.CourseTypes.CourseType.Offline
                    },
                    new()
                    {
                        Title = "Інновації у вищій аграрній освіті та сталий розвиток сільського господарства Польщі та України",
                        Ects = 150,
                        BeginsAt = new DateTime(2022,6, 13),
                        EndAt = new DateTime(2022,10,13),
                        CategoryId = 2,
                        CreatorId = 1,
                        Description = "Very interesing course",
                        CreatedDate = DateTimeOffset.Now,
                        CourseType = Infrastructure.Enums.CourseTypes.CourseType.Offline
                    },
                    new()
                    {
                        Title = "Наукове стажування для аграріїв у Кракові (Сільськогосподарський університеті ім. Гуго Коллонтая)",
                        Ects = 60,
                        BeginsAt = new DateTime(2022,8, 2),
                        EndAt = new DateTime(2022,11,2),
                        CategoryId = 2,
                        CreatorId = 1,
                        Description = "Very interesing course",
                        CreatedDate = DateTimeOffset.Now,
                        CourseType = Infrastructure.Enums.CourseTypes.CourseType.Offline
                    },
                });
            }
                


            await context.SaveChangesAsync();
        }
    }
}
