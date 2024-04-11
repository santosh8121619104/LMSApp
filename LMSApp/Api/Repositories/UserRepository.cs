using LMSApp.Api.Models;
using LMSApp.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMSApp.Api.Repositories
{
    public class UserRepository : IuserRepository
    {
        private readonly LmsContext _dbContext;

        public UserRepository(LmsContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.Include(a => a.Courses).ThenInclude(a=>a.Feedbacks).Include(a=>a.Courses).ThenInclude(a=>a.LessonSteps).Include(a => a.Feedbacks).Where(a => a.UserId == id).FirstOrDefaultAsync();
        }
    }
}
