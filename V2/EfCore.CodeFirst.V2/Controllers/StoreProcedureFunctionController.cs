namespace EfCore.CodeFirst.V2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreProcedureFunctionController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public StoreProcedureFunctionController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult FromSqlInterpolated()
        {
            _context.Users.FromSqlInterpolated($"EXEC User_GetAllUsers").ToList();

            _context.Users.FromSqlInterpolated($"SELECT * FROM [User]").ToList();

            
            SqlParameter sqlParameter = new("Id", 3);

            _context.Users.FromSqlInterpolated($"SELECT * FROM [User] WHERE Id={sqlParameter}").Single();
            _context.Users.FromSqlInterpolated($"EXEC User_GetUserById {sqlParameter}").ToList();

            return Ok();
        }
    }
}
