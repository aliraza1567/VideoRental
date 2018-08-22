using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MovieController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _dbContext.Movies
                .Where(movie => movie.NumberInStock >0);

            if (!string.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(c => c.Name.Contains(query));
            }

            var moviesdb = moviesQuery.ToList();

            return Ok(Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDto>>(moviesdb));
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(mov => mov.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CraeteMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = _dbContext.Movies.SingleOrDefault(mov => mov.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movie);
            _dbContext.SaveChanges();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovieActionResult(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(mov => mov.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
