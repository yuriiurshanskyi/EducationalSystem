using Microsoft.AspNetCore.Identity;

namespace EducationalSystem.Infrastructure.Entities
{
    public class RoleEntity : IdentityRole<int>
    {
        public virtual List<UserRoleEntity> UserRoles { get; set; }
    }
}
