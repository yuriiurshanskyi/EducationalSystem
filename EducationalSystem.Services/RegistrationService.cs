using EducationalSystem.Infrastructure;
using EducationalSystem.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationalSystem.Services
{
    public class RegistrationService
    {
        private readonly EducationContext _context;
        public RegistrationService(EducationContext context)
        {
            _context = context;
        }

        public async Task RegisterAsync(RegistrationEntity registration, int userId)
        {
            registration.RegistreeId = userId;

            await _context.Registrations.AddAsync(registration);
            await _context.SaveChangesAsync();
        }

        public async Task<RegistrationEntity> GetAsync(int registrationId)
        {
            return await _context.Registrations.FirstOrDefaultAsync(x => x.Id == registrationId);
        }

        public async Task<List<RegistrationEntity>> ListUserRegistrationsAsync(int userId, int skip, int take)
        {
            return await _context.Registrations.Where(x => x.RegistreeId == userId)
                                               .OrderByDescending(x => x.Course.BeginsAt)
                                               .ThenByDescending(x => x.Course.EndAt)
                                               .ToListAsync();
        }

        public async Task<List<RegistrationEntity>> ListCourseRegistrationsAsync(int courseId, int skip, int take)
        {
            return await _context.Registrations.Where(x => x.CourseId == courseId)
                                               .OrderByDescending(x => x.Course.BeginsAt)
                                               .ThenByDescending(x => x.Course.EndAt)
                                               .Skip(skip)
                                               .Take(take)
                                               .ToListAsync();
        }

        public async Task CancelRegistration(int registrationId)
        {
            var registration = await _context.Registrations.FirstOrDefaultAsync(x => x.Id == registrationId);

            _context.Registrations.Remove(registration);
            await _context.SaveChangesAsync();
        }
    }
}
