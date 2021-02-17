using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheApp.Models;
using TheApp.ViewModels;

namespace TheApp.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _ctx;

        public CustomersController()
        {
            _ctx = new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _ctx.Customers.Include("MembershipType").ToList();
            return View(customers);
        }

        // New customer form
        public ActionResult New()
        {
            var membershipTypes = _ctx.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipType = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        // Post request to create a new user
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _ctx.Customers.Add(customer);
            else
            {
                var customerInDb = _ctx.Customers.Single(u => u.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _ctx.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        // Edit customer
        public ActionResult Edit(int id)
        {
            var customer = _ctx.Customers.Include("MembershipType").SingleOrDefault(u => u.Id == id);
            if (customer == null) return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _ctx.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel); 
        }

        public ActionResult Details(int id)
        {
            var customer = _ctx.Customers.Include("MembershipType").SingleOrDefault(u => u.Id == id);
            if (customer == null) return HttpNotFound();
            
            return View();
        }
    }
}