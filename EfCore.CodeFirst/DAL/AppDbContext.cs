using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace EfCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        private readonly DbConnection _connection;

        public AppDbContext()
        {
        }

        public AppDbContext(DbConnection connection)
        {
            _connection = connection;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentTotal> StudentTotals { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        //public DbSet<StudentTeacherFull> StudentTeacherFulls { get; set; }
        public IQueryable<StudentTeacherFull> GetStudentTeacherFulls(int age) => FromExpression(() => GetStudentTeacherFulls(age));
        public int GetStudentCountByAge(int age)
        {
            throw new NotSupportedException("Direkt kullanıma uygun değildir. Ef Core tarafından desteklemez. Linq metot içerisinde kullanmalısınız.");
        }

        //Her Db işleminde buraya uğrayacaktır.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

            if (_connection is default(DbConnection))
            {
                optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
            }
            else
            {
                optionsBuilder.UseSqlServer(_connection);
            }

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); //global olarak tracking kapatma.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasOne(p => p.Brand).WithMany(p => p.Vehicles).HasForeignKey(p => p.BrandId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentTotal>().HasNoKey().ToTable(p => p.ExcludeFromMigrations());

            modelBuilder.Entity<StudentTeacherFull>().HasNoKey().ToTable(p => p.ExcludeFromMigrations());
            //modelBuilder.Entity<StudentTeacherFull>().ToFunction("fc_student_teacher_full");
            modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetStudentTeacherFulls), new[] { typeof(int) })).HasName("fc_student_teacher_full_id");

            modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetStudentCountByAge), new[] { typeof(int) })).HasName("fc_student_teacher_count");

            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Product>().Property(p => p.CreatedDate).ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>().HasIndex(x => x.Id); //Normal index
            modelBuilder.Entity<Product>().HasIndex(x => new { x.Id, x.SalesPrice }); //composite index

            modelBuilder.Entity<Product>().ToTable(x => x.HasCheckConstraint("ProductSalesPriceCheck", "[Price]>[SalesPrice]"));
            //modelBuilder.Entity<Product>().HasCheckConstraint("ProductSalesPriceCheck", "[Price]>[SalesPrice]"); //HasCheckConstraint (Eski Yöntem)

            //modelBuilder.Entity<Product>().Property(p => p.SalesPrice).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("[Price]*[Kdv]"); //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            //modelBuilder.Entity<Product>().Property(p => p.CreatedDate).ValueGeneratedOnAdd(); //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            //modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedNever(); //[DatabaseGenerated(DatabaseGeneratedOption.None)]

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
