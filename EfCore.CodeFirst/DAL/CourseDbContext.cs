using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace EfCore.CodeFirst.DAL
{
    public class CourseDbContext : DbContext
    {
        private readonly DbConnection _connection;

        public CourseDbContext()
        {
        }

        public CourseDbContext(DbConnection connection)
        {
            _connection = connection;
        }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

            if (_connection is default(DbConnection))
            {
                optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("CourseSqlCon"));
            }
            else
            {
                optionsBuilder.UseSqlServer(_connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasKey(p => p.Id);
            modelBuilder.Entity<Course>().ToTable("Course");
        }
    }
}
