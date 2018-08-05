using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customersdb = _dbContext.Customers.ToList();
            return Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customersdb);
        }

        public CustomerDto GetCustomer(int id)
        {
            var customersdb = _dbContext.Customers.SingleOrDefault(cus => cus.Id == id);

            if (customersdb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Customer, CustomerDto>(customersdb);
        }

        [HttpPost]
        public CustomerDto GetCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        [HttpPut]
        public CustomerDto GetCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _dbContext.Customers.SingleOrDefault(cus => cus.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerInDb);
            _dbContext.SaveChanges();

            return Mapper.Map<Customer, CustomerDto>(customerInDb);
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _dbContext.Customers.SingleOrDefault(cus => cus.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _dbContext.Customers.Remove(customerInDb);
            _dbContext.SaveChanges();
        }
    }
}
