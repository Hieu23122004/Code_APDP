using ASP.NET_SIMS.Models;

namespace ASP.NET_SIMS.Services
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
