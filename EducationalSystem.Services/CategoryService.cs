using EducationalSystem.Infrastructure;
using EducationalSystem.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
 
namespace EducationalSystem.Services
{
    public class CategoryService
    {
        private readonly EducationContext _context;

        public CategoryService(EducationContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryEntity>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
