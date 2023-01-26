using Microsoft.AspNetCore.Http.HttpResults;

namespace EfCore.CodeFirst.V2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public TransactionsController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Structure()
        {
            Post post = new()
            {
                Title = "",
                Content = ""
            };

            _context.Posts.Add(post); // 1 - Post Ekleme İşlemi

            Tag tag = _context.Tags.First();
            tag.Name = $"[Updated] {tag.Name}"; // 2 - Tag Güncelleme İşlemi

            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult TwoRelatedTables()
        {
            UserDetail userDetail = new()
            {
                PhoneNumber = "5000000000"
            };

            _context.UserDetails.Add(userDetail);

            User user = new()
            {
                Name = "Cihat",
                Age = 1,
                UserDetail = userDetail
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult TwoRelatedTablesTransaction()
        {
            using var transaction = _context.Database.BeginTransaction();

            UserDetail userDetail = new()
            {
                PhoneNumber = "5000000000"
            };

            _context.UserDetails.Add(userDetail);
            _context.SaveChanges(); // <-- SaveChanges()

            User user = new()
            {
                Name = "Cihat",
                Age = 1,
                UserDetail = userDetail
            };

            _context.Users.Add(user);
            _context.SaveChanges();  // <-- 2.kez SaveChanges()

            transaction.Commit();

            return Ok();
        }
    }
}
