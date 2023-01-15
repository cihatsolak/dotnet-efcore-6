using Microsoft.EntityFrameworkCore;

namespace Concurrency.Web.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);

            modelBuilder.Entity<Product>().HasCheckConstraint("StockCanBeAtLeastZero", "[Stock]>=0");

            modelBuilder.Entity<Product>().Property(p => p.RowVersion).IsRowVersion();

            base.OnModelCreating(modelBuilder);
        }
    }
}
