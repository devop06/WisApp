using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WisApp.Models;
using WisApp.Controllers;

namespace WisApp.DAL
{
    public class WisContext : DbContext
    {

        public WisContext()
            : base("WisContext")
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