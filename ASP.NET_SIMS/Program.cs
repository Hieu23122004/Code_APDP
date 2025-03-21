using ASP.NET_SIMS.Data;
using ASP.NET_SIMS.Repositories;
using ASP.NET_SIMS.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SIMS.Services;

var builder = WebApplication.CreateBuilder(args);

// Thêm authentication bằng Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Trang đăng nhập
        options.LogoutPath = "/Account/Logout"; // Trang đăng xuất
        options.AccessDeniedPath = "/Account/AccessDenied"; // Trang từ chối truy cập
    });

builder.Services.AddAuthorization(); // Bật Authorization

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IGradeService, GradeService>();
// Đăng ký session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); 
app.UseAuthentication(); 
app.UseAuthorization(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();

    //1. Đăng kí lưu vào database
    //2. Login lấy dữ liệu ở database
    //3. Phân quyền Admin. faculty, student
    //4. Admin thêm sửa xóa khóa học
    //5. Admin thêm sửa xóa sinh viên
    //6. Admin gán khóa học cho sinh viên
    //7. Sinh viên xem đc khóa học của mình