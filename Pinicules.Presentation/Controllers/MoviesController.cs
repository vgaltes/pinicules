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
        public ActionResult Index()
        {
            List<MovieDTO> movies = moviesService.GetMovies();

            var model = new MoviesSearchResult() 
            { 
                Items = movies.Select(m => new MovieSearchItem { Id = m.Id, Title = m.Title }).ToList()
            };

            return View(model);
        }
    }
}