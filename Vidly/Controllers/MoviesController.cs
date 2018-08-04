using System;
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

        [Route("movies")]
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

        [Route("movies/new")]
        public ActionResult New()
        {
            var movieViewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = _dbContext.Genres.ToList()
            };

            return View("MovieForm", movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _dbContext.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _dbContext.Movies.Add(movie);
            }
            else
            {
                var moviewInDb = _dbContext.Movies.Single(mov => mov.Id == movie.Id);


                moviewInDb.Name = movie.Name;
                moviewInDb.ReleaseDate = movie.ReleaseDate;
                moviewInDb.Genre = movie.Genre;
                moviewInDb.NumberInStock = movie.NumberInStock;
            }

            _dbContext.SaveChanges();
            return RedirectToAction("GetAllMovies", "Movies");
        }

        public ActionResult Edit(int movieId)
        {
            var movie = _dbContext.Movies.SingleOrDefault(mov => mov.Id == movieId);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _dbContext.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}