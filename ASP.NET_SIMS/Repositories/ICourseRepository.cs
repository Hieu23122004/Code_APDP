using SIMS.Models;
using System.Collections.Generic;

namespace ASP.NET_SIMS.Repositories
{
    public interface ICourseRepository
    {
        List<Course> GetAllCourses();
        Course GetCourseById(int id);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }
}
