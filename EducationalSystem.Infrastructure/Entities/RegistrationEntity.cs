namespace EducationalSystem.Infrastructure.Entities
{
    public class RegistrationEntity
    {
        public int Id { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public int RegistreeId { get; set; }
        public virtual UserEntity Registree { get; set; }
        public int CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
    }
}
