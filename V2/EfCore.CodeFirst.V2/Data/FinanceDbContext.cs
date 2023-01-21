﻿namespace EfCore.CodeFirst.V2.Data
{
    public sealed class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> dbContextOptions) : base(dbContextOptions)
        {
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
    }
}