namespace EfCore.CodeFirst.V2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IsolationsController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public IsolationsController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Test()
        {
            using var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted);

            User user01 = new()
            {
                Name = "Deneme 1",
                Age = 50
            };

            _context.Users.Add(user01);
            _context.SaveChanges();

            User user02 = new()
            {
                Name = "Deneme 2",
                Age = 50
            };

            _context.Users.Add(user02);
            _context.SaveChanges();

            transaction.Commit();

            return Ok();
        }
    }
}
