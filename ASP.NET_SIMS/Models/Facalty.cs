using ASP.NET_SIMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMS.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }

        [Required, StringLength(200)]
        public string FullName { get; set; }  // Thêm FullName

        [Required, StringLength(100)]
        public string Department { get; set; }

        [Required, StringLength(15)]
        public string PhoneNumber { get; set; }
    }
}
