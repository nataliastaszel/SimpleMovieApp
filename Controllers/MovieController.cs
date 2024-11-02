using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class MovieController : Controller
    {
        private static IList<Movie> movies = new List<Movie>
        {
            new Movie() { Id = 1, Title = "Batman", Description = "opis filmu1", Price = 3 },
            new Movie() { Id = 2, Title = "Batman 2", Description = "opis filmu2", Price = 5 },
            new Movie() { Id = 3, Title = "Błękitna Laguna", Description = "opis filmu3", Price = 3 },
        };

        public ActionResult Index()
        {
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }


        public ActionResult Create()
        {
            return View(new Movie());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            movie.Id = movies.Count + 1;
            movies.Add(movie);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            var movie = movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie updatedMovie)
        {
            var movie = movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            movie.Title = updatedMovie.Title;
            movie.Description = updatedMovie.Description;
            movie.Price = updatedMovie.Price;
            
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(int id)
        {
            var movie = movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var movie = movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                movies.Remove(movie);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}