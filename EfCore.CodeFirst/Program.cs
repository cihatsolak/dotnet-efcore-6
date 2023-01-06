using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

Initializer.Build();


// repetable read
using (var _context = new CourseDbContext())
{
    using (var _transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.Snapshot))
    {
        var course1 = _context.Courses.AsNoTracking().ToList();


        var course2 = _context.Courses.AsNoTracking().ToList();

        _transaction.Commit();
    }
}

// serializable
using (var _context = new CourseDbContext())
{
    using (var _transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
    {
        var course = _context.Courses.ToList();

        _transaction.Commit();
    }
}

// repetable read
using (var _context = new CourseDbContext())
{
    using (var _transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
    {
        var course = _context.Courses.Find(1);


        _transaction.Commit();
    }
}

// read committed
using (var _context = new CourseDbContext())
{
    using (var _transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
    {
        _context.Courses.Add(new Course
        {
            Name = "Test"
        });

        _context.SaveChanges();

        _transaction.Commit();
    }
}

// read uncommitted
using (var _context = new CourseDbContext())
{
    using (var _transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
    {
        _context.Courses.Add(new Course
        {
            Name = "Test"
        });

        //var course = _context.Courses.Find(1);
        //course.Name = "çiçek";

        _context.SaveChanges();

        _transaction.Commit();
    }
}

//DbConnection appDbConnection = new SqlConnection(Initializer.Configuration.GetConnectionString("SqlCon"));
//DbConnection courseDbConnection = new SqlConnection(Initializer.Configuration.GetConnectionString("CourseSqlCon"));

//using var _appDbContext = new AppDbContext(appDbConnection);
//using var appDbTransaction = _appDbContext.Database.BeginTransaction();

//_appDbContext.Brands.Add(new Brand
//{
//    Name = "Transaction Model"
//});

//_appDbContext.SaveChanges();

//using var _courseDbContext = new AppDbContext(appDbConnection);
//_courseDbContext.Database.UseTransaction(appDbTransaction.GetDbTransaction());

//var course = _courseDbContext.Students.First();
//course.Name = "Transaction Mesut";

//_courseDbContext.Students.Update(course);
//_courseDbContext.SaveChanges();

//appDbTransaction.Commit();



//using (var _context = new AppDbContext())
//{
//    using var transaction = _context.Database.BeginTransaction();

//    Brand brand = new()
//    {
//        Name = "Seat"
//    };

//    _context.Brands.Add(brand);
//    _context.SaveChanges();

//    Vehicle vehicle = new()
//    {
//        Plate = "06BEU013",
//        Year = "2018",
//        BrandId = 23
//    };

//    _context.Vehicles.Add(vehicle);
//    _context.SaveChanges();

//    transaction.Commit();
//}


//using (var _context = new AppDbContext())
//{
//    var productDtos = _context.Products.ProjectTo<ProductDto>(ObjectMapper.Mapper.ConfigurationProvider).ToList();
//}

//using (var _context = new AppDbContext())
//{
//    //scaler-function 1.yol
//    var products = _context.Products.Select(p => new
//    {
//        name = p.Name,
//        studentCount = _context.GetStudentCountByAge(25)
//    }).ToList();

//    //scaler-function 2.yol
//    SqlParameter ageSqlParameter = new("age", 25);
//    int total = _context.StudentTotals.FromSqlInterpolated($"select dbo.fc_student_teacher_count({ageSqlParameter}) as Total").First().Total;
//}

using (var _context = new AppDbContext())
{
    //Function 1.yol
    //SqlParameter ageSqlParameter = new("age", 36);
    //var studentTeacherFull = _context.StudentTeacherFulls.FromSqlInterpolated($"select * from fc_student_teacher_full_id({ageSqlParameter})").ToList();

    //Function 2.Yol (temiz)
    var studentTeacherFull = _context.GetStudentTeacherFulls(45).Where(p => p.StudentAge == 25).ToList();

}

using (var _context = new AppDbContext())
{

    //SqlParameter entityIdSqlParameter = new("addedId", System.Data.SqlDbType.Int);
    //entityIdSqlParameter.Direction = System.Data.ParameterDirection.Output;

    //_context.Database.ExecuteSqlInterpolated($"exec sp_insert_product 'cihat', 500, 23, {entityIdSqlParameter} out");

    //int id = (int)entityIdSqlParameter.Value;

    //SqlParameter sqlParameter = new("id", 4);
    //var products = _context.Products.FromSqlRaw("exec sp_get_products_by_id {0}", 4).ToList();
    //var products2 = _context.Products.FromSqlInterpolated($"exec sp_get_products_by_id @id={sqlParameter}").ToList();

    //var products = _context.Products.FromSqlInterpolated($"exec sp_get_products").ToList();
    //var products2 = _context.Products.FromSqlRaw("exec sp_get_products").ToList();

    //var student = _context.Students
    //          .TagWith("Bu sorgu ürünlere ait 1 numaralı ürünleri getirir.")
    //          .First(p => p.Id == 1);

    //var product = _context.Students.FromSqlRaw<Student>("select * from students where Age={0}", 2).First();

    //SqlParameter sqlParameter = new("age", 2);
    //var product2 = _context.Students.FromSqlInterpolated($"select * from students where Age={sqlParameter}").First();


    //var result = _context.Students.Join(_context.Teachers, student => student.Name, teacher => teacher.Name, (student, teacher) =>
    //new
    //{
    //    StudentName = student.Name,
    //    TeacherName = teacher.Name,
    //    StudentAge = student.Age
    //}).ToList();

    //var result2 = (from students in _context.Students
    //               join teacher in _context.Teachers on students.Name equals teacher.Name
    //               select new
    //               {
    //                   StudentName = students.Name,
    //                   TeacherName = teacher.Name,
    //                   StudentAge = students.Age
    //               }).ToList();


    //var product = _context.Products.AsNoTracking().First();
    //product.Name = "cihat";

    //_context.Entry(product).State = EntityState.Modified;
    //_context.SaveChanges();

    //_context.Entry(products).Reference(x => x.ProductFeature).Load();

    //_context.Products.Add(new Product
    //{
    //    Kdv = 18,
    //    Barcode = 1,
    //    Name = "Ef Test",
    //    Price = 12,
    //    SalesPrice = 1,
    //    Stock = 1,
    //    CreatedDate = DateTime.Now
    //});

    _context.SaveChanges();

    var aa = 1;
}

using (var _context = new AppDbContext())
{
    var products = _context.Products.ToList();

    products.ForEach(p =>
    {
        p.Stock += 100;
    });

    _context.ChangeTracker.Entries().ToList().ForEach(e =>
    {
        if (e.Entity is Product p)
        {
            Console.WriteLine(e.State);
        }
    });

    _context.SaveChanges();

    // _context.SaveChanges();

    // var products = await _context.Products.AsNoTracking().ToListAsync();

    //products.ForEach(p =>
    //{
    //    Console.WriteLine($"{p.Id} :{p.Name} - {p.Price} - {p.Stock}");
    //});
}