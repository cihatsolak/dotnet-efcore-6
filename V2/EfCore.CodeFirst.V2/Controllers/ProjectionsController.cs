namespace EfCore.CodeFirst.V2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectionsController : ControllerBase
    {
        private readonly FinanceDbContext _context;
        private readonly IMapper _mapper;

        public ProjectionsController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AutoMapper()
        {
            var shirts = _context.Shirts.Select(p => new Shirt
            {
                Name = p.Name,
                Stock = p.Stock,
                SalesPrice = p.SalesPrice
            }).ToList();

            var shirtDtos = _context.Shirts.ProjectTo<ShirtDto>(_mapper.ConfigurationProvider).ToList();

            return Ok();
        }

        [HttpGet]
        public IActionResult Include()
        {
            //Yöntem 1
            _context.Users
                .Include(p => p.UserDetail)
                .Select(p => new
                {
                    p.Name,
                    p.UserDetail.PhoneNumber //One-To-One
                }).ToList();

            //Yöntem 2
            _context.Users.Select(p => new
            {
                p.Name,
                p.UserDetail.PhoneNumber //One-To-One
            }).ToList();

            return Ok();
        }
    }
}
