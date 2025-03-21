using ASP.NET_SIMS.Models;
using ASP.NET_SIMS.Services;
using SIMS.Models;
namespace ASP.NET_SIMS.Services
{
    public interface IAuthService
    {
        Task<bool> Register(User user);
        User Authenticate(string email, string password);
    

    }
}
