using LMSApp.Api.Models;
using LMSApp.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMSApp.Api.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly LmsContext _dbContext;

        public CourseRepository(LmsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _dbContext.Courses.Include(a => a.Lessons).ThenInclude(a=>a.LessonSteps).Include(a => a.Instructor).Where(a => a.CourseId == id).FirstOrDefaultAsync();
        }

        public async Task<IQueryable<Course>> GetAllAsync()
        {
            return  _dbContext.Courses.Include(a => a.Lessons).AsQueryable();
        }

        public async Task AddAsync(Course course)
        {
            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Course course)
        {
            _dbContext.Entry(course).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Course course = await _dbContext.Courses.SingleOrDefaultAsync(a => a.CourseId == id);
            _dbContext.Set<Course>().Remove(course);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
