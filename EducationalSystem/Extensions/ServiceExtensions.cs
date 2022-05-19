using EducationalSystem.Configs;
using EducationalSystem.Infrastructure;
using EducationalSystem.Infrastructure.Entities;
using EducationalSystem.Services;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;

namespace EducationalSystem.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<UserEntity, RoleEntity>(options => IdentityServerConfig.GetIdentityOptions())
                    .AddEntityFrameworkStores<EducationContext>()
                    .AddDefaultTokenProviders()
                    .AddUserStore<UserStore<UserEntity, RoleEntity, EducationContext, int, IdentityUserClaim<int>,
                                            UserRoleEntity, IdentityUserLogin<int>, IdentityUserToken<int>, IdentityRoleClaim<int>>>()
                    .AddRoleStore<RoleStore<RoleEntity, EducationContext, int, UserRoleEntity, IdentityRoleClaim<int>>>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 options.Authority = "https://localhost:7021";
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateAudience = false
                 };
             });
        }

        public static void AddIdentityServerConfiguration(this IServiceCollection services, string connectionString)
        {
            var migrationAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentityServer(options =>
            {
                options.EmitStaticAudienceClaim = false;
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.IssuerUri = "https://localhost:7021";
            })
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                .AddAspNetIdentity<UserEntity>()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b =>
                        b.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)),
                            sql => sql.MigrationsAssembly(migrationAssembly));
                }).AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b =>
                        b.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)),
                            sql => sql.MigrationsAssembly(migrationAssembly));

                    options.EnableTokenCleanup = true;
                })
                .AddInMemoryClients(IdentityServerConfig.GetClients());
        }

        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EducationContext>(options =>
            {
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)));
            });
        }

        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddTransient<UserService>();
            services.AddTransient<CategoryService>();
            services.AddTransient<CourseService>();
            services.AddTransient<RegistrationService>();
        }
        
    }
}
