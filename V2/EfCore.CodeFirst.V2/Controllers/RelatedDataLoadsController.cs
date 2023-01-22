namespace EfCore.CodeFirst.V2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RelatedDataLoadsController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public RelatedDataLoadsController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Explicit()
        {
            var user = _context.Users.Find(3);

            if (true) //Any business rule
            {
                _context.Entry(user).Reference(p => p.UserDetail).Load(); //one-to-one-relation-ship
            }

            if (true) //Any business rule
            {
                _context.Entry(user).Collection(p => p.Addresses).Load(); //one-to-many-relation-ship
            }

            return Ok(user);
        }
    }
}
