using ASP.NET_SIMS.Models;
using ASP.NET_SIMS.Data;
using Microsoft.EntityFrameworkCore;
namespace ASP.NET_SIMS.Repositories
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly AppDbContext _context;

        public StudentCourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void EnrollStudent(int studentId, int courseId)
        {
            if (!_context.StudentCourses.Any(sc => sc.StudentID == studentId && sc.CourseID == courseId))
            {
                var studentCourse = new StudentCourse
                {
                    StudentID = studentId,
                    CourseID = courseId,
                    EnrollmentDate = DateTime.Now,
                    Status = "Enrolled"
                };
                _context.StudentCourses.Add(studentCourse);
                _context.SaveChanges();
            }
        }

        public IEnumerable<StudentCourse> GetEnrollmentsByCourse(int courseId)
        {
            return _context.StudentCourses.Where(sc => sc.CourseID == courseId)
                .Include(sc => sc.Student).ToList();
        }

        public IEnumerable<StudentCourse> GetEnrollmentsByStudent(int studentId)
        {
            return _context.StudentCourses.Where(sc => sc.StudentID == studentId)
                .Include(sc => sc.Course).ToList();
        }
    }

}
