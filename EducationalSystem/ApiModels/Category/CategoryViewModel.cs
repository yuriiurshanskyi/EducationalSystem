namespace EducationalSystem.ApiModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string Links { get; set; }
    }
}
