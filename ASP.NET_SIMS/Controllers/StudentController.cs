using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.NET_SIMS.Data;
using ASP.NET_SIMS.Models;
using System.Security.Claims;


namespace SIMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // Xem khóa học của sinh viên
        public async Task<IActionResult>MyCourse()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Console.WriteLine($"Debug: UserID from Claims - {userId}");

            // Lấy danh sách StudentCourses nhưng không Include Course
            var studentCourses = await _context.StudentCourses
                .Where(sc => sc.Student.UserID == userId)
                .ToListAsync();

            // Debug số lượng dữ liệu lấy được
            Console.WriteLine($"Debug: StudentCourses count - {studentCourses.Count}");

            // Lấy thông tin Course thủ công
            foreach (var sc in studentCourses)
            {
                sc.Course = await _context.Courses.FindAsync(sc.CourseID);
                Console.WriteLine($"Debug: Course - {sc.Course?.CourseName ?? "NULL"}, StudentID - {sc.StudentID}");
            }

            if (!studentCourses.Any())
            {
                ViewBag.Message = "Bạn chưa đăng ký khóa học nào.";
                return View(new List<StudentCourse>());
            }

            return View(studentCourses);
        }


        // Xem điểm của sinh viên
        public IActionResult Grade()
        {
            return View();
        }


    }
}
