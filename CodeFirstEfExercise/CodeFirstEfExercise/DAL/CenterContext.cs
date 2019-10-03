using CodeFirstEfExercise.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

//Acessing the database we are creating
namespace CodeFirstEfExercise.DAL
{
    public class CenterContext : DbContext
    {

        public CenterContext() : base("CenterContext")
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<Info> Infos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //This line makes the Table names singular ("Animal"), without it they will be plural ("Animals")
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}