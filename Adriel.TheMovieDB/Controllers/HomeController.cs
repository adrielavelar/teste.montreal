﻿using Adriel.TheMovieDB.Domain;
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
            var discoverMovies = _movieController.DiscoverMovieWithReleaseDateGreaterOneYear();
            ViewBag.ListMovies = discoverMovies.Result.results;

            return View();
        }

        [HttpPost]
        public ActionResult Search(string Text)
        {
            var searchMovies = _movieController.Search(Text);
            TempData["SearchListMovies"] = searchMovies.Result.results;

            return Json(Url.Action("SearchResult", "Home"));
        }

        public ActionResult SearchResult()
        {
            ViewBag.SearchListMovies = TempData["SearchListMovies"];
            return View();
        }

        public ActionResult MovieDetails(long Id)
        {
            var movie = _movieController.GetMovieDetails(Id);
            ViewBag.Movie = movie;

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