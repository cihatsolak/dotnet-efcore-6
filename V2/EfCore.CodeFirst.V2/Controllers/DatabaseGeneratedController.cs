namespace EfCore.CodeFirst.V2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public sealed class DatabaseGeneratedController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public DatabaseGeneratedController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Identity()
        {
            var shirt = _context.Shirts.Find(1);

            shirt.Name = $"{new Random().Next(1, 100)}--{shirt.Name}";

            _context.SaveChanges();

            return Ok();
        }
    }
}
