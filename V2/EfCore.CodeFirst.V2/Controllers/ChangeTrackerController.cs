namespace EfCore.CodeFirst.V2.Controllers
{
    [Route("api/[controller]/[action]")]
    public sealed class ChangeTrackerController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public ChangeTrackerController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Detached()
        {
            Bank bank = new();
            EntityState entityState = _context.Entry(bank).State;

            return Ok(entityState);
        }

        [HttpGet]
        public IActionResult UnChanged()
        {
            Bank bank = _context.Banks.Find(1);

            EntityState entityState = _context.Entry(bank).State;
           
            return Ok(entityState);
        }

        [HttpGet]
        public IActionResult UpdateByTracking()
        {
            //Tracking

            Bank bank1 = _context.Banks.Find(1);
            bank1.Name = "Alternatif Bank";

            _context.SaveChanges();


            //Non-Tracking
            Bank bank2 = new()
            {
                Id = 1,
                Name = "Denizbank"
            };

            _context.Banks.Update(bank2);
            _context.SaveChanges();

            return Ok();
        }
    }
}





