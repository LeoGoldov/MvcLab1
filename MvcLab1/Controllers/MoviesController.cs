using Microsoft.AspNetCore.Mvc;
using MvcLab1.Models;
using MvcLab1.Repositories;

namespace MvcLab1.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _repository;

        public MoviesController(IMovieRepository repository)
        {
            _repository = repository;
        }

        // GET: /Movies
        public IActionResult Index()
        {
            var movies = _repository.GetAll();
            return View(movies);
        }

        // GET: /Movies/Details/5
        public IActionResult Details(int id)
        {
            var movie = _repository.GetById(id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }

        // GET: /Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(movie);
                TempData["SuccessMessage"] = $"Фильм \"{movie.Title}\" успешно добавлен!";
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: /Movies/Edit/5
        public IActionResult Edit(int id)
        {
            var movie = _repository.GetById(id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }

        // POST: /Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Movie movie)
        {
            if (id != movie.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _repository.Update(movie);
                TempData["SuccessMessage"] = $"Фильм \"{movie.Title}\" успешно обновлен!";
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: /Movies/Delete/5
        public IActionResult Delete(int id)
        {
            var movie = _repository.GetById(id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _repository.GetById(id);
            _repository.Delete(id);
            TempData["SuccessMessage"] = $"Фильм \"{movie?.Title}\" удален!";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Movies/ByGenre/Драма
        public IActionResult ByGenre(string genre)
        {
            var movies = _repository.GetByGenre(genre);
            ViewBag.Genre = genre;
            return View(movies);
        }

        // GET: /Movies/HighRated
        public IActionResult HighRated()
        {
            var movies = _repository.GetHighRated(8.0m);
            return View("Index", movies);
        }
    }
}