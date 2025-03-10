using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlockBuster;
using BlockBuster.Models;
using BlockBuster.WebApp.Helpers;

namespace BlockBuster.WebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            var movie = BasicFunctions.GetMovieWithDetailsById(id);
            return View(movie);
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = DropDownFormat.FormatGenres();
            ViewBag.DirectorId = DropDownFormat.FormatDirectors();
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movieToCreate)
        {
            try
            {
                BlockBusterAdminFunctions.AddMovie(movieToCreate);
                return RedirectToAction("Movies", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = BasicFunctions.GetMovieWithDetailsById(id);
            ViewBag.GenreId = DropDownFormat.FormatGenres();
            ViewBag.DirectorId = DropDownFormat.FormatDirectors();
            return View(movie);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movieToEdit)
        {
            try
            {
                BlockBusterAdminFunctions.EditMovie(movieToEdit);
                return RedirectToAction("Movies", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            var movie = BasicFunctions.GetMovieWithDetailsById(id);
            return View(movie);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Movie movie)
        {
            try
            {
                BlockBusterAdminFunctions.DeleteMovie(movie.MovieId);
                return RedirectToAction("Movies", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
