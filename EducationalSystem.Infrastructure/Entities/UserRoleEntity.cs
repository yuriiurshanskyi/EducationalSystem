using Microsoft.AspNetCore.Identity;

namespace EducationalSystem.Infrastructure.Entities
{
    public class UserRoleEntity : IdentityUserRole<int>
    {
        public virtual RoleEntity Role { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
