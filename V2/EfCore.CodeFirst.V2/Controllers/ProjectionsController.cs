namespace EfCore.CodeFirst.V2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectionsController : ControllerBase
    {
        private readonly FinanceDbContext _context;
        private readonly IMapper _mapper;

        public ProjectionsController(FinanceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
    }
}
