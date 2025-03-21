using ASP.NET_SIMS.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_SIMS.Models
{
    public class Student
    {
        internal object StudentCourse;

        [Key]
        public int StudentID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }

        [Required, StringLength(200)]
        public string FullName { get; set; }  // Thêm FullName

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required, StringLength(200)]
        public string Address { get; set; }

        [Required, StringLength(15)]
        public string PhoneNumber { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        // Một sinh viên có thể tham gia nhiều khóa học
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }

}
