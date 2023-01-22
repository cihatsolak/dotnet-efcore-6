namespace EfCore.CodeFirst.V2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeleteBehaviorController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public DeleteBehaviorController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpDelete]
        public IActionResult Cascade()
        {
            var brand = _context.Brands.First();

            _context.Brands.Remove(brand);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Restrict()
        {
            var brand = _context.Brands.First();

            try
            {
                _context.Brands.Remove(brand);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

            return NoContent();
        }

        [HttpDelete]
        public IActionResult SetNull()
        {
            var brand = _context.Brands.First();

            try
            {
                _context.Brands.Remove(brand);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

            return NoContent();
        }
    }
}
