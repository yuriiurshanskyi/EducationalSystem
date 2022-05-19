using AutoMapper;
using EducationalSystem.ApiModels;
using EducationalSystem.Infrastructure.Entities;
using EducationalSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EducationalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        public UserController(IMapper mapper, UserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> CreateUserAsync([FromBody] SignUpModel model)
        {
            var user = _mapper.Map<UserEntity>(model);

            await _userService.CreateUserAsync(user, model.Password);

            return Ok();
        }

        [Authorize(Roles = "RegisteredUser")]
        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DeleteUserAsync()
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _userService.DeleteUserAsync(userId);

            return Ok();
        }

        [Authorize(Roles = "RegisteredUser")]
        [HttpGet("getUserInfo")]
        public async Task<IActionResult> GetUser()
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var user = await _userService.GetUserAsync(userId);

            var result = _mapper.Map<UserViewModel>(user);

            return Ok(result);
        }
    }
}
