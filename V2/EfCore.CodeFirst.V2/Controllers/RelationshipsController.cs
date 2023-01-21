namespace EfCore.CodeFirst.V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationshipsController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public RelationshipsController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult ManyToManyInsert()
        {
            var post = _context.Posts.Include(p => p.Tags).Single(p => p.Id == 1);

            List<Tag> tags = new()
            {
                new Tag
                {
                    Name = "e-devlet"
                },

                new Tag
                {
                    Name = "şifre"
                }
            };

            post.Tags.AddRange(tags);

            _context.SaveChanges();

            return Ok(post);
        }

        [HttpPut]
        public IActionResult ManyToManyUpdate()
        {
            var post = _context.Posts.Include(p => p.Tags).Single(p => p.Id == 1);

            post.Title = $"[Updated] {post.Title}";

            if (post.Tags is not null)
            {
                post.Tags[0].Name = $"[Updated] {post.Tags[0].Name}";
            }

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult ManyToManyDelete(int tagId)
        {
            var post = _context.Posts.Include(p => p.Tags).Single(p => p.Id == 1);

            Tag tagToBeDeleted = post.Tags.SingleOrDefault(p => p.Id == tagId);
            if (tagToBeDeleted is not null)
            {
                post.Tags.Remove(tagToBeDeleted);
            }

            _context.SaveChanges();

            return NoContent();
        }
    }
}
