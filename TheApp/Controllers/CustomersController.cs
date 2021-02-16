using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheApp.Models;

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

        public ActionResult Details(int id)
        {
            var customer = _ctx.Customers.SingleOrDefault(u => u.Id == id);
            if (customer == null) return HttpNotFound();
            return View(customer);
        }
    }
}