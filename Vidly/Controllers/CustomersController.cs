using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        [Route("customers")]
        public ActionResult GetAllCustomers()
        {
            var customerViewModel = new CustmersViewModel
            {
                Customers = _dbContext.Customers.Include(cus => cus.MembershipType).ToList()
            };

            return View(customerViewModel);
        }

        [Route("customers/getcustomerbyid/{id}")]
        public ActionResult GetCustomerById(int id)
        {
            var customer = _dbContext.Customers.Include(cus => cus.MembershipType).FirstOrDefault(cus => cus.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [Route("customers/new")]
        public ActionResult New()
        {
            var newCustomerViewModel = new CustomerFormViewModel
            {
                MembershipTypes = _dbContext.MembershipTypes.ToList()
            };

            return View("CustomerForm", newCustomerViewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _dbContext.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _dbContext.Customers.Single(cus => cus.Id == customer.Id);


                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _dbContext.SaveChanges();
            return RedirectToAction("GetAllCustomers", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(cus => cus.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _dbContext.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}