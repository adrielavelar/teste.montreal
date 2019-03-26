using Adriel.TheMovieDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adriel.TheMovieDB.Controllers
{
    public class HomeController : Controller
    {
        private MovieDB _movieController = new MovieDB();

        public ActionResult Index()
        {
            var teste = _movieController.Search("batman");
            var teste2 = _movieController.GetMovieDetails(343611);

            return View();
        }

        public ActionResult Search(string text, FormCollection formCollection)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}