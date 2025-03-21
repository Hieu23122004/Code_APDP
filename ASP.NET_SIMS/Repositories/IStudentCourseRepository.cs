using ASP.NET_SIMS.Models;

namespace ASP.NET_SIMS.Repositories
{
    public interface IStudentCourseRepository
    {
        void EnrollStudent(int studentId, int courseId);
        IEnumerable<StudentCourse> GetEnrollmentsByCourse(int courseId);
        IEnumerable<StudentCourse> GetEnrollmentsByStudent(int studentId);
    }
}
