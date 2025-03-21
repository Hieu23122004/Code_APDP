using ASP.NET_SIMS.Models;
using ASP.NET_SIMS.Data;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_SIMS.Services;
using ASP.NET_SIMS.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace ASP.NET_SIMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public AccountController(AppDbContext context, IUserRepository userRepository, IAuthService authService)
        {
            _context = context;
            _userRepository = userRepository;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _authService.Authenticate(email, password);
            if (user == null)
            {
                ViewBag.Message = "Sai tài khoản hoặc mật khẩu.";
                return View();
            }

            // Tạo danh sách Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),  // Thêm UserId vào Claims
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { IsPersistent = true };

            // Đăng nhập bằng Cookie Authentication
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                    new ClaimsPrincipal(claimsIdentity), authProperties);

            // Lưu Role vào Session nếu cần
            HttpContext.Session.SetString("UserRole", user.Role);

            return user.Role switch
            {
                "Admin" => RedirectToAction("ManagerCourse", "Admin"),
                "Faculty" => RedirectToAction("AssignGrade", "Faculty"),
                "Student" => RedirectToAction("MyCourse", "Student"),
                _ => RedirectToAction("Register")
            };
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email đã được sử dụng.");
                    return View(model);
                }
                _context.Users.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(model);
        }


    }
}
