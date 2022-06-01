namespace EducationalSystem.ApiModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTimeOffset MemberFrom { get; set; }
    }
}
