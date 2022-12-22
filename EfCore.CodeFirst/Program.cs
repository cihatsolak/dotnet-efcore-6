﻿Initializer.Build();

using (var _context = new AppDbContext())
{
    var product = _context.Products.AsNoTracking().First();
    product.Name = "cihat";

    _context.Entry(product).State = EntityState.Modified;
    _context.SaveChanges();

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