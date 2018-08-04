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

        // GET: Customers
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
    }
}