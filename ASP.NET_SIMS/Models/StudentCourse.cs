using SIMS.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_SIMS.Models
{
    public class StudentCourse
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        // Ngày sinh viên đăng ký khóa học
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        // Trạng thái đăng ký (ví dụ: Đang học, Đã hoàn thành, Đã hủy, ...)
        public string Status { get; set; } = "Enrolled";
    }

}
