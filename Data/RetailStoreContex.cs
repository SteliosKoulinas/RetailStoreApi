using Microsoft.EntityFrameworkCore;
using fromscratch_back.Models;

namespace fromscratch_back.Data
{
    public class RetailStoreContext : DbContext
    {
        public RetailStoreContext(DbContextOptions<RetailStoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
               => options.UseSqlite("Data Source=RetailStore.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
                      {
                          entity.Property(e => e.Name)
                                .IsRequired();
                      });
            modelBuilder.Entity<Customer>(entity =>
           {
               entity.Property(e => e.FirstName)
                     .IsRequired();

               entity.Property(e => e.LastName)
                     .IsRequired();

               entity.Property(e => e.Email)
                     .IsRequired();
           });
    }
}
}



