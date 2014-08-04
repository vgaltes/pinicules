using Pinicules.Domain.DTOs;
using Pinicules.Domain.Services;
using Pinicules.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pinicules.Presentation.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        // GET: Movies
        public ActionResult Search(string searchTerm = "")
        {
            var model = new MoviesSearchResult() { Items = new List<MovieSearchItem>() };

            return View(model);
        }

        public PartialViewResult SearchMovies(string searchTerm = "")
        {
            List<MovieDTO> movies = moviesService.GetMovies();

            var model = new MoviesSearchResult() 
            { 
                Items = movies.Select(m => new MovieSearchItem { Id = m.Id, Title = m.Title, Image = m.Image }).ToList()
            };

            return PartialView(model);
        }
    }
}