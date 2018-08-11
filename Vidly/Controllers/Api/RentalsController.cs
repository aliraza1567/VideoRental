using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public RentalsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalsDto rentalsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (rentalsDto.MovieIds.Count == 0)
            {
                return BadRequest("No Movie Ids has been given");
            }

            var customerDb = _dbContext.Customers.SingleOrDefault(customer => customer.Id == rentalsDto.CustomerId);

            if (customerDb == null)
            {
                return BadRequest("Invalid Customer Id");
            }

            var moviesDb = _dbContext.Movies.Where(movie => rentalsDto.MovieIds.Contains(movie.Id)).ToList();

            if (moviesDb.Count != rentalsDto.MovieIds.Count)
            {
                return BadRequest("One or more Movies Ids are invalid");
            }

            foreach (var movie in moviesDb)
            {
                // Edge Case
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("One or more Movies are not available");
                }

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customerDb,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                movie.NumberAvailable -= 1;
                _dbContext.Rentals.Add(rental);
            }

            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
