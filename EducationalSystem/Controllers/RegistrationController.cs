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
    public class RegistrationController : ControllerBase
    {
        private readonly RegistrationService _registrationService;
        private readonly IMapper _mapper;

        public RegistrationController(RegistrationService registrationService, IMapper mapper)
        {
            _registrationService = registrationService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        [Authorize(Roles = "RegisteredUser")]
        public async Task<IActionResult> RegistrerAsync([FromBody] PostRegistrationModel model)
        {
            var entity = _mapper.Map<RegistrationEntity>(model);

            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _registrationService.RegisterAsync(entity, userId);

            return Ok();
        }

        [HttpGet("listCourseRegistrations")]
        public async Task<IActionResult>  ListCourseRegistrationAsync(int courseId, int skip, int take)
        {
            var registrations = await _registrationService.ListCourseRegistrationsAsync(courseId, skip, take);

            var result = _mapper.Map<List<RegistrationViewModel>>(registrations);

            return Ok(result);
        }

        [HttpGet("listUserRegistrations")]
        public async Task<IActionResult> ListUserRegistrationAsync(int skip, int take)
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var registrations = await _registrationService.ListUserRegistrationsAsync(userId, skip, take);

            var result = _mapper.Map<List<RegistrationViewModel>>(registrations);

            return Ok(result);
        }

        [HttpDelete("cancel")]
        public async Task<IActionResult> CancelRegistrationsAsync(int registrationId)
        {
            await _registrationService.CancelRegistration(registrationId);

            return Ok();
        }
    }
}
