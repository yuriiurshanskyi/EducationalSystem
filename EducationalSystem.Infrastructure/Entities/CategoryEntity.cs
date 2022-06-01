namespace EducationalSystem.Infrastructure.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryCode { get; set; }

        public virtual List<CourseEntity> Courses { get; set; }
    }
}
