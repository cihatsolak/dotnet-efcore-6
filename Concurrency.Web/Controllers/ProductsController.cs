using Concurrency.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Concurrency.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ProductsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult List()
        {
            var products = _appDbContext.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _appDbContext.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            try
            {
                _appDbContext.Products.Update(product);
                _appDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var currentProduct = dbUpdateConcurrencyException.Entries[0].Entity as Product; //Kullanıcının güncellemek istediği data
                var databasePropertyValues = dbUpdateConcurrencyException.Entries[0].GetDatabaseValues(); //Veri tabanından entity'nin değerini almak

                if (databasePropertyValues is null) //veri tabanında değeri yoksa entity daha önce silinmiştir.
                {
                    ModelState.AddModelError(string.Empty, "Bu ürün başka bir kullanıcı tarafından silindi.");
                    return View(product);
                }

                var databaseProductEntity = databasePropertyValues.ToObject() as Product; //veri tabanından değeri alınan entity'i Product sınıfına dönüştürme

                ModelState.AddModelError(string.Empty, "Bu ürün başka bir kullanıcı tarafından güncellendi.");
            }

            return View(product);
        }
    }
}
