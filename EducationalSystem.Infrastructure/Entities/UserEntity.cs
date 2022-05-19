using Microsoft.AspNetCore.Identity;

namespace EducationalSystem.Infrastructure.Entities
{ 
    public class UserEntity : IdentityUser<int>
    {
        public string Name { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public virtual List<UserRoleEntity> UserRoles { get; set; }
        public virtual List<CourseEntity> Courses { get; set; }
        public virtual List<RegistrationEntity> Registrations { get; set; }
    }
}
