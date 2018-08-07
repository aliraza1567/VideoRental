using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IHttpActionResult GetCustomers()
        {
            var customersdb = _dbContext.Customers
                .Include(customer => customer.MembershipType)
                .ToList();
            return Ok(Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customersdb));
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customersdb = _dbContext.Customers.SingleOrDefault(cus => cus.Id == id);

            if (customersdb == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customersdb));
        }

        [HttpPost]
        public IHttpActionResult GetCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customer.Id) , Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPut]
        public IHttpActionResult GetCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _dbContext.Customers.SingleOrDefault(cus => cus.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(customerDto, customerInDb);
            _dbContext.SaveChanges();

            return Ok(Mapper.Map<Customer, CustomerDto>(customerInDb));
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _dbContext.Customers.SingleOrDefault(cus => cus.Id == id);

            if (customerInDb == null)
            {
                return BadRequest();
            }

            _dbContext.Customers.Remove(customerInDb);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
