using ASP.NET_SIMS.Data;
using ASP.NET_SIMS.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_SIMS.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        Task IUserRepository.AddUser(User user)
        {
            throw new NotImplementedException();
        }
        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        Task<User> IUserRepository.GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
