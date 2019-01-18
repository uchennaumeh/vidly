using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using System.Data.Entity;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        //declare a private field to connect to the database
        private ApplicationDbContext _context;


        //initialize the _context
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //-context is a disposable object so it has to be disposed
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MemberShipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MemberShipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
           if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };
                return View("customerForm", viewModel);
            }
            if (customer.id ==0)
            _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.id == customer.id);


                //Mapper.Map(custmer, customerInDb);
                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}