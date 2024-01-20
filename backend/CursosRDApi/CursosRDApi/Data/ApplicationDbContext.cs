using CursosRDApi.Models;
using CursosRDApi.Models.CourseModels;
using CursosRDApi.Models.StudentModels;
using CursosRDApi.Models.TeacherModels;
using CursosRDApi.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace CursosRDApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Course> Course {  get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<CourseSubscription> CourseSubscription { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role{ get; set; }



    }
}
