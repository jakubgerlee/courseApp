using System.Configuration;
using System.Data.Entity;
using Register.Data.Layer.Models;

namespace Register.Data.Layer.DbContexts
{
    public class RegisterDbContext : DbContext
    {
        public RegisterDbContext() : base(GetConnectionString())
        { }

        public DbSet<Student> StudentDbSet { get; set; }
        public DbSet<Course> CourseDbSet { get; set; }
        public DbSet<CourseDay> CourseDayDbSet { get; set; }
        public DbSet<Homework> HomeworkDbSet { get; set; }


        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["RegisterSqlDb"].ConnectionString;
        }

    }
}

