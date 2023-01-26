using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public IActionResult AddUser()
        {
            //CREATE PROCEDURE [dbo].[SP_User_InsertUser]
            // @Name varchar(100),
            // @Age int,
            // @Id int output
            //AS
            //BEGIN
            // INSERT INTO [User]([Name], Age) VALUES (@Name, @Age)
            // SET @Id=SCOPE_IDENTITY();
            // RETURN @Id
            //END

            SqlParameter addedUserId = new("Id", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            _context.Database.ExecuteSqlInterpolated($"EXEC SP_User_InsertUser 'Cihat', 60, {addedUserId} out");

            

            int id = (int)addedUserId.Value;

            return Ok(id);
        }
    }
}
