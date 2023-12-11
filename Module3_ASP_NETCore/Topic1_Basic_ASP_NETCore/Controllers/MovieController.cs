using Microsoft.AspNetCore.Mvc;
using Topic1_Basic_ASP_NETCore.Models;

namespace Topic1_Basic_ASP_NETCore.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            var genre = new List<Genre>();
            genre.Add(new Genre { Id=1, Name="Action"});
            genre.Add(new Genre { Id = 2, Name = "Comedy" });
            genre.Add(new Genre { Id = 3, Name = "18+" });

            var data = new List<Movie>();
            data.Add(new Movie { Id = 1, Title = "ABC", Description = "ABC123", GenreId=1 });
            data.Add(new Movie { Id = 2, Title = "DEF", Description = "DEF123", GenreId=1 });
            data.Add(new Movie { Id = 3, Title = "GHK", Description = "GHK123", GenreId=3 });
            return View("List", data);
        }
    }
}
