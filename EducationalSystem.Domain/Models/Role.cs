using Microsoft.AspNetCore.Identity;

namespace EducationalSystem.Domain.Models
{
    public class Role : IdentityRole<int>
    {
        public virtual List<UserRole> UserRoles { get; set; }
    }
}
