namespace EducationalSystem.Infrastructure.Entities
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public DateOnly BeginsAt { get; set; }
        public DateOnly EndAt { get; set; }
        public string Links { get; set; }
        public int CreatorId { get; set; }
        public int CategoryId { get; set; }
        public virtual UserEntity CreatedBy { get; set; }
        public virtual CategoryEntity Category { get; set; }
        public virtual List<RegistrationEntity> Registrations { get; set; }
    }
}
