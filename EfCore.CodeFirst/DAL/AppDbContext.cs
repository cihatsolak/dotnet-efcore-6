namespace EfCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


        //Her Db işleminde buraya uğrayacaktır.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductFeature>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().HasOne(p => p.ProductFeature).WithOne(p => p.Product).HasForeignKey<ProductFeature>(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(100).IsFixedLength();

            //n-n relationships
            modelBuilder.Entity<Student>()
                .HasMany(p => p.Teachers)
                .WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>("StudentTeacher",
                x => x.HasOne<Teacher>().WithMany().HasForeignKey("TeacherId").HasConstraintName("FK_TeacherId"),
                x => x.HasOne<Student>().WithMany().HasForeignKey("StudentId").HasConstraintName("FK_StudentId")
                );

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.Entries().ToList().ForEach(e =>
            {
                if (e.Entity is Product p)
                {
                    if (e.State == EntityState.Added)
                    {
                        p.CreatedDate = DateTime.Now;
                    }
                }
            });

            return base.SaveChanges();
        }
    }
}
