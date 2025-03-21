using ASP.NET_SIMS.Models;

namespace ASP.NET_SIMS.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task AddUser(User user);
    }
}
