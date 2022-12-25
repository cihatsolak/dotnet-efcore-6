using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    //scaler-function 1.yol
    var products = _context.Products.Select(p => new
    {
        name = p.Name,
        studentCount = _context.GetStudentCountByAge(25)
    }).ToList();
}

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

    SqlParameter entityIdSqlParameter = new("addedId", System.Data.SqlDbType.Int);
    entityIdSqlParameter.Direction = System.Data.ParameterDirection.Output;

    _context.Database.ExecuteSqlInterpolated($"exec sp_insert_product 'cihat', 500, 23, {entityIdSqlParameter} out");

    int id = (int)entityIdSqlParameter.Value;

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