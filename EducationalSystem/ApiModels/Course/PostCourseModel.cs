namespace EducationalSystem.ApiModels
{
    public class PostCourseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly BeginsAt { get; set; }
        public DateOnly EndAt { get; set; }
        public string Links { get; set; }
    }
}
