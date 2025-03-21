using ASP.NET_SIMS.Services;
using ASP.NET_SIMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMS.Models;
using SIMS.Services;
using ASP.NET_SIMS.Models;

namespace SIMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly AppDbContext _context;
        private readonly IStudentService _studentService;
        public AdminController(ICourseService courseService, AppDbContext context, IStudentService studentService)
        {
            _courseService = courseService;
            _context = context;
            _studentService = studentService;
        }

        public IActionResult AssignStudent()
        {
            ViewBag.Students = _context.Students.ToList();
            ViewBag.Courses = _context.Courses.ToList();

            var studentCourses = _context.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .ToList();

            return View(studentCourses);
        }

        [HttpPost]
        public IActionResult AssignStudent(int studentId, int courseId)
        {
            _courseService.AssignStudentToCourse(studentId, courseId);
            return RedirectToAction("AssignStudent"); 
        }



        public IActionResult ManagerCourse()
        {
            var courses = _courseService.GetAllCourses();
            return View(courses);
        }

        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseService.AddCourse(course);
                return RedirectToAction("ManagerCourse");
            }
            return View("ManagerCourse", _courseService.GetAllCourses());
        }

        [HttpPost]
        public IActionResult UpdateCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                var existingCourse = _courseService.GetCourseById(course.CourseID);
                if (existingCourse != null)
                {
                    existingCourse.CourseName = course.CourseName;
                    existingCourse.Description = course.Description;
                    existingCourse.Credits = course.Credits;
                    existingCourse.StartDate = course.StartDate;
                    existingCourse.EndDate = course.EndDate;
                    existingCourse.Status = course.Status;

                    _courseService.UpdateCourse(existingCourse); // Gọi service để cập nhật

                    return RedirectToAction("ManagerCourse");
                }
            }
            return View("ManagerCourse", _courseService.GetAllCourses());
        }

        [HttpPost]
        public IActionResult DeleteCourse(int id)
        {
            _courseService.DeleteCourse(id);
            return RedirectToAction("ManagerCourse");
        }


        public IActionResult ManagerStudent()
        {
            var students = _studentService.GetAllStudents();
            return View(students);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _studentService.AddStudent(student);
            return RedirectToAction("ManagerStudent");
        }

        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            _studentService.UpdateStudent(student);
            return RedirectToAction("ManagerStudent");
        }

        [HttpPost]
        public IActionResult DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
            return RedirectToAction("ManagerStudent");
        }
    }
}
