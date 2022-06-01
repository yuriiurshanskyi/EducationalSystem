using static EducationalSystem.Infrastructure.Enums.CourseTypes;

namespace EducationalSystem.Services.DomainModels
{
    public class FilterModel
    {
        public CourseType? Type { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Ects { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
