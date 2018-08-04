using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie
            {
                Name = "Sherk!@"
            };

            var customers = new List<Customer>
            {
                new Customer{Name = "Ali"},
                new Customer{Name = "Wajeeh"}
            };

            var randomViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(randomViewModel);
        }

        public ActionResult GetAllMovies()
        {
            var moviesViewModel = new MovieViewModel
            {
                Movies = _dbContext.Movies.ToList()
            };

            return View(moviesViewModel);
        }

        [Route("movies/getmoviebyid/{movieid}")]
        public ActionResult GetMovieById(int movieId)
        {
            var movie = _dbContext.Movies.FirstOrDefault(mov => mov.Id == movieId);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
    }
}