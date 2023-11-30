using Atelier_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Atelier_2.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationdbContext _db;
        public MovieController(ApplicationdbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var movies = _db.movies.ToList();
            return View(movies);
        }

        public IActionResult Create()

        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            _db.movies.Add(movie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)

        {
            var movie = new Movie { Id = Id };
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie m)
        {
            var movie = _db.movies.Find(m.Id);
            if (movie == null)
              {
                  return Content(" incorrect id ! ");
               }
            else { 
                movie.Name = m.Name;
                movie.GenreId = m.GenreId;
                _db.SaveChanges();
                
                return RedirectToAction(nameof(Index));
                }
        }
        
        public IActionResult Delete(int Id)

        {
            var movie = _db.movies.Find(Id);
            return View(movie);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Movie movie)
        {
            if (movie == null)
            {
                return Content(" incorrect id ! ");
            }
            else
            {
                _db.movies.Remove(movie);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
        }

    }
}
