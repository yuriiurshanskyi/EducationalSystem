using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;

namespace EducationalSystem.Configs
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new("EducationalSystem.Api", "EducationalSystem.Api",
                    new[] { JwtClaimTypes.Name, JwtClaimTypes.Role, JwtClaimTypes.Id })
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new("EducationalSystem.Api", "EducationalSystem.Api",
                    new[] { JwtClaimTypes.Name, JwtClaimTypes.Role, JwtClaimTypes.Id })
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new()
                {
                    ClientId = "user",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    RequireClientSecret = false,
                    AllowedScopes = { "EducationalSystem.Api",
                                       IdentityServerConstants.StandardScopes.OpenId},
                    AllowOfflineAccess = true
                }
            };
        }

        public static IdentityOptions GetIdentityOptions()
        {
            IdentityOptions options = new IdentityOptions();

            options.User.RequireUniqueEmail = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireDigit = true;

            return options;
        }
    }
}
