using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using Topic2_WorkingEF.Models;

namespace Topic2_WorkingEF.Controllers
{
    public class MovieController : Controller
    {
        private readonly PE_PRN_Fall2023B1Context db;

        public MovieController(PE_PRN_Fall2023B1Context _db)
        {
            db=_db;
        }

        // Load all Movies
        public IActionResult Index()
        {
            var movies = db.Movies.Include(m=>m.Genres).Include(m=>m.Director).ToList();
            // Trả về cho view 'Index' dữ liệu được lấy từ DB thông qua model
            return View(movies);
        }

        public IActionResult Create()
        {
            ViewBag.Genres = db.Genres.ToList();
            ViewBag.Directors = new SelectList(db.Directors.ToList(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie) 
        {
            if(ModelState.IsValid)
            {
                var newMovie = new Movie
                {
                    Title = movie.Title,
                    Year = movie.Year,
                    Description = movie.Description,
                    DirectorId = movie.DirectorId
                };
                var genres = movie.Genres;
                db.Movies.Add(newMovie);
                db.SaveChanges();
                TempData["msg"] = "Add new success.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["msg"] = "Add false.";
                return View();
            }
        }
    }
}
