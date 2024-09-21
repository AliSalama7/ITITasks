using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class DemoContext : DbContext
    {
        public DemoContext() : base()
        {
        }
        public DemoContext(DbContextOptions<DemoContext> options) : base(options) 
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("Data Source=MSI;Initial Catalog=DemoDb;Integrated Security=True;Trust Server Certificate=True");
        //}
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<crsResult> CrsResults { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
