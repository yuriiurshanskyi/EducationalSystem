using EducationalSystem.Infrastructure;
using EducationalSystem.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EducationalSystem.Services
{
    public class UserService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly EducationContext _context;
        public UserService(UserManager<UserEntity> userManager, 
                           EducationContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task CreateUserAsync(UserEntity user, string password)
        {
            await _userManager.CreateAsync(user, password);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if(user is not null)
                await _userManager.DeleteAsync(user);
        }

        public async Task<UserEntity> GetUserAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            return user;
        }
    }
}
