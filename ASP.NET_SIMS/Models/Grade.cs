using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMS.Models
{
    public class Grade
    {
        [Key]
        public int GradeID { get; set; }

        [ForeignKey("Enrollment")]
        public int EnrollmentID { get; set; }

        [ForeignKey("Faculty")]
        public int? FacultyID { get; set; } // Nullable để tránh lỗi
        public virtual Faculty Faculty { get; set; }

        [Range(0, 100)]
        public double Score { get; set; }
    }

}
