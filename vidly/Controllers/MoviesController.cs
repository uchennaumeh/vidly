using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;
using System.Data.Entity;
using vidly.Migrations;
using System.Data.Entity.Validation;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        //declare a private field to connect to the database
        private ApplicationDbContext _context;


        //initialize the _context
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //-context is a disposable object so it has to be disposed
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies/Random
        public ActionResult Index()
        {
            var movie = _context.Movies.Include(c => c.Genre).ToList();
            
            return View(movie);
        
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                //remove next line so we can have a dedicated view model
                //Movie = new Movie(),
                Genres = genre
            };
            return View("MovieForm", viewModel);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {

                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
            
                    _context.Movies.Add(movie);
              
            }
                
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);


                //Mapper.Map(custmer, customerInDb);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;

            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                Console.WriteLine(e);
            }
            

            return RedirectToAction("Index", "Movies");

            
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
               

                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }


    }
}