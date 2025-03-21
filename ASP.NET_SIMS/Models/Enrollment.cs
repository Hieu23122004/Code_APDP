using ASP.NET_SIMS.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMS.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        // Liên kết đến điểm số
        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }

}
