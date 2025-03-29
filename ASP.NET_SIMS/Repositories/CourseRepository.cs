using ASP.NET_SIMS.Data;
using SIMS.Models;
using System.Collections.Generic;
using System.Linq;

namespace ASP.NET_SIMS.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.Find(id);
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            var existingCourse = _context.Courses.Find(course.CourseID);
            if (existingCourse != null)
            {
                existingCourse.CourseName = course.CourseName;
                existingCourse.Description = course.Description;
                existingCourse.Credits = course.Credits;
                existingCourse.StartDate = course.StartDate;
                existingCourse.EndDate = course.EndDate;
                existingCourse.Status = course.Status;
                _context.SaveChanges();
            }
        }

        public void DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
    }
}
