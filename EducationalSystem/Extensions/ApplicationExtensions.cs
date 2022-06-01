using EducationalSystem.Configs;
using EducationalSystem.Helpers;
using EducationalSystem.Infrastructure;
using EducationalSystem.Infrastructure.Entities;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EducationalSystem.Extensions
{
    public static class ApplicationExtensions
    {
        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();

            var appDbContext = serviceScope.ServiceProvider.GetRequiredService<EducationContext>();
            appDbContext.Database.Migrate();

            var persistedGrantDbContext = serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>();
            persistedGrantDbContext.Database.Migrate();

            var configurationDbContext = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            configurationDbContext.Database.Migrate();

            if (!configurationDbContext.IdentityResources.Any())
            {
                foreach (var resorce in IdentityServerConfig.GetIdentityResources())
                {
                    configurationDbContext.IdentityResources.Add(resorce.ToEntity());
                }

                configurationDbContext.SaveChanges();
            }

            if (!configurationDbContext.ApiResources.Any())
            {
                foreach (var resorce in IdentityServerConfig.GetApiResources())
                {
                    configurationDbContext.ApiResources.Add(resorce.ToEntity());
                }

                configurationDbContext.SaveChanges();
            }

            if (!configurationDbContext.Clients.Any())
            {
                foreach (var resorce in IdentityServerConfig.GetClients())
                {
                    configurationDbContext.Clients.Add(resorce.ToEntity());
                }

                configurationDbContext.SaveChanges();
            }

            if (!configurationDbContext.ApiScopes.Any())
            {
                foreach (var resorce in IdentityServerConfig.GetApiScopes())
                {
                    configurationDbContext.ApiScopes.Add(resorce.ToEntity());
                }

                configurationDbContext.SaveChanges();
            }

            if (!appDbContext.Users.Any())
            {
                SeedData.InitializeAsync(appDbContext,
                    serviceScope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>(),
                    serviceScope.ServiceProvider.GetRequiredService<RoleManager<RoleEntity>>()).Wait();
            }

            SeedData.InitializeDbAsync(appDbContext).Wait();
        }
    }
}
