using Adriel.TheMovieDB.Domain;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Adriel.TheMovieDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDB _movieController = new MovieDB();

        public ActionResult Index()
        {
            var discoverMovies = _movieController.DiscoverMovieWithReleaseDateGreaterOneYear();
            ViewBag.ListMovies = discoverMovies.Result.results;

            return View();
        }

        [HttpPost]
        public ActionResult Search(string Text)
        {
            var searchMovies = _movieController.Search(Text);
            TempData["SearchListMovies"] = searchMovies.Result.results;

            return Json(Url.Action(nameof(SearchResult), "Home"));
        }

        public ActionResult SearchResult()
        {
            ViewBag.SearchListMovies = TempData["SearchListMovies"];
            return View();
        }

        public ActionResult MovieDetails(long? Id = null)
        {
            if (Id != null)
            {
                var movie = _movieController.GetMovieDetails((long)Id);
                ViewBag.Movie = movie.Result;

                return View();
            }
            else
            {
                return RedirectToAction(nameof(Index), "Home");
            }
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

        public ActionResult FileOfUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileOfUpload(HttpPostedFileBase postedFile)
        {
            var savedFiles = 0;
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file.ContentLength > 0)
                {
                    var uploadPath = Server.MapPath("~/Content/Uploads");

                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    file.SaveAs(Path.Combine(uploadPath, file.FileName));
                    savedFiles++;
                }
            }

            if (savedFiles > 0)
                ViewBag.Message = "File(s) uploaded(s) successfully.";

            return View();
        }
    }
}