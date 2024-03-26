using LMSApp.Api.Models;
using LMSApp.Pages;

namespace LMSApp.Api.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> GetByIdAsync(int id);
        Task<IEnumerable<Course>> GetAllAsync();
        Task AddAsync(Course course);
        Task UpdateAsync(Course course);
        Task<bool> DeleteAsync(int Id);
    }
}
