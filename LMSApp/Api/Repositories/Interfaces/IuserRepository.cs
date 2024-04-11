using LMSApp.Api.Models;

namespace LMSApp.Api.Repositories.Interfaces
{
    public interface IuserRepository
    {
        Task<User> GetByIdAsync(int id);
    }
}
