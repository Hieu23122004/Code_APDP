using ASP.NET_SIMS.Models;
using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required, StringLength(100)]
        public string CourseName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public int Credits { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Thêm trạng thái khóa học
        public string Status { get; set; } = "Active";
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    }
}
