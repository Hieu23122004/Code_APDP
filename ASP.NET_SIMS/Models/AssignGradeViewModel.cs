using Microsoft.AspNetCore.Mvc.Rendering;
using SIMS.Models;

namespace ASP.NET_SIMS.Models
{
    public class AssignGradeViewModel
    {
        public int EnrollmentID { get; set; }
        public int FacultyID { get; set; }
        public double Score { get; set; }
        public List<Student> Students { get; set; } = new();

        // Danh sách khóa học của sinh viên
        public List<StudentCourse> StudentCourses { get; set; } = new();

        // Danh sách điểm số đã được chấm trước đó
        public List<Grade> AssignedGrades { get; set; } = new();
    }

}
