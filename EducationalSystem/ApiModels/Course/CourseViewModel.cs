namespace EducationalSystem.ApiModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateOnly BeginsAt { get; set; }
        public DateOnly EndAt { get; set; }
        public CategoryViewModel Category { get; set; }
        public int CreatorId { get; set; }
    }
}
