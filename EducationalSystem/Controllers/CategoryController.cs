using AutoMapper;
using EducationalSystem.ApiModels;
using EducationalSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(CategoryService categoryService, 
                                  IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("categories")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();

            var result = _mapper.Map<List<CategoryViewModel>>(categories);

            return Ok(result);
        }
    }
}
