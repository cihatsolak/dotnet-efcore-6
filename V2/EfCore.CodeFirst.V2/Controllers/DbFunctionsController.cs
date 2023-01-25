namespace EfCore.CodeFirst.V2.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DbFunctionsController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public DbFunctionsController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult TableValued()
        {
            _context.UserGalleryFull.ToList(); //Parametresiz table-valued function

            SqlParameter ageSqlParameter = new("age", 19);  //Parametreli table-valued function
            _context.UserGalleryFull.FromSqlInterpolated($"select * from fc_user_gallery_by_age({ageSqlParameter})").ToList(); 

            return Ok();
        }
    }
}
