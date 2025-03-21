using System.ComponentModel.DataAnnotations;

namespace ASP.NET_SIMS.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // "Admin", "Faculty", "Student"

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
