using AutoMapper;
using EducationalSystem.ApiModels;
using EducationalSystem.Infrastructure.Entities;
using EducationalSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EducationalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(CourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        [Authorize(Roles = "Provider")]
        public async Task<IActionResult> CreateCourseAsync([FromBody] PostCourseModel model)
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var course = _mapper.Map<CourseEntity>(model);

            await _courseService.AddCourseAsync(course, userId);

            return Ok();
        }

        [HttpPost("edit")]
        [Authorize(Roles = "Provider")]
        public async Task<IActionResult> EditCourseAsync([FromBody] CourseViewModel model)
        {
            var course = _mapper.Map<CourseEntity>(model);

            await _courseService.EditCourseAsync(course);

            return Ok();
        }

        [HttpGet("get")]
        [Authorize(Roles = "RegisteredUser")]
        public async Task<IActionResult> GetCourseAsync(int id)
        {
            var result = await _courseService.GetCourseAsync(id);

            return Ok(result);
        }

        [HttpGet("listRecommended")]
        [Authorize(Roles = "RegisteredUser")]
        public async Task<IActionResult> GetRecommendedCoursesAsync(int skip, int take)
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var result = await _courseService.ListRecommendedCoursesAsync(userId, skip, take);

            return Ok(result);
        }

        [HttpGet("list")]
        [Authorize(Roles = "RegisteredUser")]
        public async Task<IActionResult> GetCoursesAsync(int skip, int take)
        {
            var result = await _courseService.ListCoursesAsync(skip, take);

            return Ok(result);
        }

        [HttpDelete("delete")]
        [Authorize(Roles = "RegisteredUser")]
        public async Task<IActionResult> DeleteCourseAsync(int courseId)
        {
            await _courseService.DeleteCourseAsync(courseId);

            return Ok();
        }
    }
}
