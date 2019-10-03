using CodeFirstEfExercise.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

//Acessing the database we are creating
namespace CodeFirstEfExercise.DAL
{
    public class SchoolContext : DbContext
    {

        public SchoolContext() : base("SchoolContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //This line makes the Table names singular ("Student"), without it they will be plural ("Students")
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}