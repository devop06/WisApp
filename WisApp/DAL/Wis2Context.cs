using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WisApp.Models;
using WisApp.Controllers;

namespace WisApp.DAL
{
    public class Wis2Context : DbContext
    {

        public Wis2Context()
            : base("Wis2Context")
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Article> Article { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}