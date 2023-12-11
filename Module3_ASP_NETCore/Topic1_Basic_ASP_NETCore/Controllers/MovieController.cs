using Microsoft.AspNetCore.Mvc;
using Topic1_Basic_ASP_NETCore.Models;

namespace Topic1_Basic_ASP_NETCore.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            var genres = new List<Genre>();
            genres.Add(new Genre { Id=1, Name="Action"});
            genres.Add(new Genre { Id = 2, Name = "Comedy" });
            genres.Add(new Genre { Id = 3, Name = "18+" });
            // Truyền danh sách Genre sang View
            //ViewData["genres"] = "List of Genres";
            //ViewBag.Genre = new Genre { Id=4, Name="Action", Description="Action movie"};
            //TempData["Movie"] = new Movie { Id = 4, Title = "XXX", Description = "YYY", GenreId = 3 };

            ViewBag.Genres = genres;

            var data = new List<Movie>();
            data.Add(new Movie { Id = 1, Title = "ABC", Description = "ABC123", GenreId=1 });
            data.Add(new Movie { Id = 2, Title = "DEF", Description = "DEF123", GenreId=1 });
            data.Add(new Movie { Id = 3, Title = "GHK", Description = "GHK123", GenreId=3 });
            return View("List", data);
        }

        public IActionResult Create()
        {
            var genres = new List<Genre>();
            genres.Add(new Genre { Id = 1, Name = "Action" });
            genres.Add(new Genre { Id = 2, Name = "Comedy" });
            genres.Add(new Genre { Id = 3, Name = "18+" });

            ViewBag.Genres = genres;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            var genres = new List<Genre>();
            genres.Add(new Genre { Id = 1, Name = "Action" });
            genres.Add(new Genre { Id = 2, Name = "Comedy" });
            genres.Add(new Genre { Id = 3, Name = "18+" });

            ViewBag.Genres = genres;

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["msg_error"] = "Create false.";
                return View();
            }
            
        }
    }
}
