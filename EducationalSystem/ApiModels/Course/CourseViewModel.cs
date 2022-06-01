namespace EducationalSystem.ApiModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTime BeginsAt { get; set; }
        public DateTime EndAt { get; set; }
        public CategoryViewModel Category { get; set; }
        public CreatorViewModel Creator { get; set; }
    }
}
