using static EducationalSystem.Infrastructure.Enums.CourseTypes;

namespace EducationalSystem.ApiModels
{
    public class PostCourseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string BeginsAt { get; set; }
        public string EndAt { get; set; }
        public int Ects { get; set; }
        public int CategoryId { get; set; }
        public CourseType CourseType { get; set; }
    }
}
