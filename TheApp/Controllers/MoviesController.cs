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
        private ApplicationDbContext _ctx;
        public MoviesController()
        {
            _ctx = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var movies = _ctx.Movies.Include("Genre").ToList();
            return View(movies);
        }

        public ActionResult Save()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var movie = _ctx.Movies.Include("Genre").SingleOrDefault(u => u.Id == id);
            if (movie == null) return HttpNotFound();
            return View(movie);
        }
    }
}