using Microsoft.EntityFrameworkCore;
using ASP.NET_SIMS.Models;
using SIMS.Models;
namespace ASP.NET_SIMS.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; } 
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Grade> Grades { get; set; }

    }
}
