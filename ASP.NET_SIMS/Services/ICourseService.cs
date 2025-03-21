using SIMS.Models;

namespace ASP.NET_SIMS.Services
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();
        Course GetCourseById(int id);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
        void AssignStudentToCourse(int studentId, int courseId);
    }
}
