using Microsoft.AspNetCore.Identity;

namespace EducationalSystem.Infrastructure.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<CourseEntity> {get;set;}
    }
}
