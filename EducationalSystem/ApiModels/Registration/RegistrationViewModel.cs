namespace EducationalSystem.ApiModels
{
    public class RegistrationViewModel
    {
        public int Id { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public int RegistreeId { get; set; }
        public CourseViewModel Course { get; set; }
    }
}
