using Microsoft.EntityFrameworkCore;

namespace WebAppStudent_Repositary_Pattern.Data
{
    public class StudentDbContext :DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Students> Students { get; set; }
        public DbSet<Models.Courses> Courses { get; set; }
        public DbSet<Models.Enrollments> Enrollments { get; set; }
    }
}
