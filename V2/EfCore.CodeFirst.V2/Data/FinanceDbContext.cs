using EfCore.CodeFirst.V2.Data.Entities.Galleries;

namespace EfCore.CodeFirst.V2.Data
{
    public sealed class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            ChangeTracker.Entries().ToList().ForEach(entry =>
            {
                if (entry.Entity is BaseEntity baseEntity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        baseEntity.CreatedDate = DateTime.Now;
                        baseEntity.UpdatedDate = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        baseEntity.UpdatedDate = DateTime.Now;
                    }
                }
            });

            return base.SaveChanges();
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Shirt> Shirts { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
    }
}
