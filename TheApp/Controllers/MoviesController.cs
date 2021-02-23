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

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = _ctx.Genre.ToList()
            };
            return View("MovieForm", viewModel);
        }

        // Post request to create a new user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _ctx.Genre.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _ctx.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _ctx.Movies.Single(u => u.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _ctx.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _ctx.Movies.Include("Genre").SingleOrDefault(u => u.Id == id);
            if (movie == null) return HttpNotFound();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _ctx.Genre.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = _ctx.Movies.Include("Genre").SingleOrDefault(u => u.Id == id);
            if (movie == null) return HttpNotFound();
            return View(movie);
        }
    }
}