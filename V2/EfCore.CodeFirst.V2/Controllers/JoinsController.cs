using EfCore.CodeFirst.V2.Data.Entities.Galleries;
using EfCore.CodeFirst.V2.Data.Entities.Users;
using EfCore.CodeFirst.V2.Models;

namespace EfCore.CodeFirst.V2.Controllers
{
    [Route("api/[controller]/[action]")]
    public sealed class JoinsController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public JoinsController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Inner()
        {
            // [Lambda Expressions] 2 tabloyu join'lemek.
            var ug1 = _context.Users.Join(_context.Galleries, user => user.Id, gallery => gallery.UserId, (user, gallery) => new UserGalleryDto
            {
                Age = user.Age,
                Year = gallery.Year
            });


            // [LINQ] 2 tabloyu join'lemek.
            var ug2 = from user in _context.Users
                      join gallery in _context.Galleries on user.Id equals gallery.UserId
                      select new UserGalleryDto
                      {
                          Age = user.Age,
                          Year = gallery.Year
                      };


            // [Lambda Expressions] 3 tabloyu join'lemek
            var ug3 = _context.Users
                      .Join(_context.Galleries, user => user.Id, gallery => gallery.UserId, (User, Gallery) => new { User, Gallery })
                      .Join(_context.UserDetails, joinedUserGallery => joinedUserGallery.User.Id, userDetail => userDetail.UserId, (joinedUserGallery, userDetail) => new UserGalleryDto
                      {
                          Age = joinedUserGallery.User.Age,
                          Year = joinedUserGallery.Gallery.Year,
                          PhoneNumber = userDetail.PhoneNumber
                      });

            // [LINQ] 3 tabloyu join'lemek.
            var ug4 = from user in _context.Users
                      join gallery in _context.Galleries on user.Id equals gallery.UserId
                      join userDetail in _context.UserDetails on user.Id equals userDetail.UserId
                      select new UserGalleryDto
                      {
                          Age = user.Age,
                          Year = gallery.Year,
                          PhoneNumber = userDetail.PhoneNumber
                      };

            return Ok();
        }

        [HttpGet]
        public IActionResult LeftOrRight()
        {
            var ug1 = from gallery in _context.Galleries
                      join user in _context.Users on gallery.UserId equals user.Id into userTable
                      from user in userTable.DefaultIfEmpty() //left-right join
                      select new UserGalleryDto
                      {
                          Age = user == null ? 0 : user.Age,
                          Year = gallery.Year
                      };

            return Ok();
        }
    }
}
