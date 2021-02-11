using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheApp.Models;
using TheApp.ViewModels;

namespace TheApp.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Yahia" };
            var customers = new List<Customer>
            {
                new Customer {Name="Yahia" },
                new Customer {Name="Ahmed" },
                new Customer {Name="Mohamed" },
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie, Customers = customers
            };
            return View(viewModel);
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult Edit(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Index(int? pageIndex = 1, string sortBy = "Name")
        {
            return Content(pageIndex + " " + sortBy);
        }
    }
}