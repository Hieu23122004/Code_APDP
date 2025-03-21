using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using ASP.NET_SIMS.Models;
using ASP.NET_SIMS.Repositories;
using ASP.NET_SIMS.Services;
using Microsoft.EntityFrameworkCore;
using ASP.NET_SIMS.Data;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly AppDbContext _context;

    public AuthService(IUserRepository userRepository, AppDbContext context)
    {
        _userRepository = userRepository;
        _context = context;
    }

    public User Authenticate(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        return user;
    }
    public async Task<bool> Register(User user)
    {
        // Kiểm tra xem email đã tồn tại chưa
        var existingUser = await _userRepository.GetUserByEmail(user.Email);
        if (existingUser != null)
            return false;

        // Hash mật khẩu
        user.Password = HashPassword(user.Password);

        // Thêm user mới
        await _userRepository.AddUser(user);
        return true;
    }


    private string HashPassword(string password)
    {
        byte[] salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 32
        ));
    }

    Task<bool> IAuthService.Register(User user)
    {
        throw new NotImplementedException();
    }
}
