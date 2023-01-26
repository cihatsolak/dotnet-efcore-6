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

        [HttpGet]
        public IActionResult TableValuedV2()
        {
            _context.GetUserGalleryByAge(19).Where(p => p.Name.StartsWith("M")).ToList();

            return Ok();
        }

        [HttpGet]
        public IActionResult ScalerFunction()
        {
            _context.GetUserCountByAge(12); //Bu şekilde kullanımı uygun değildir.

            _context.Galleries.Select(p => new
            {
                GalleryText = p.Text,
                UserCount = _context.GetUserCountByAge(12) //Bu metot sadece select ifadesi içerisinde kullanılabilir.
            }).ToList();


            // scaler-function 2.yol
            SqlParameter ageSqlParameter = new("age", 3);
            int total = _context.UserTotal.FromSqlInterpolated($"select dbo.fc_user_count_by_age({ageSqlParameter}) as Total").First().Total;

            return Ok(total);
        }
    }
}
