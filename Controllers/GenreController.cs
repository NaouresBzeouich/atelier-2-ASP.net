using Atelier_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atelier_2.Controllers
{
    
    public class GenreController : Controller
    {
        private readonly ApplicationdbContext _db;
        public GenreController(ApplicationdbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.genres.ToList());
        }

        public IActionResult Create()

        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre genre)
        {
            _db.genres.Add(genre);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
