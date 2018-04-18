using Stores.Data.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Stores.Data.Context
{
    public class AppDb : DbContext
    {
        public AppDb()
            : base("Stores")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            Database.SetInitializer<AppDb>(null);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            Database.CommandTimeout = 180;
        }

        #region Entity Sets                

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<SoldProduct> SoldProducts { get; set; }
        #endregion
    }
}
