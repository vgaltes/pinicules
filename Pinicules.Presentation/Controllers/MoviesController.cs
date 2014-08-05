﻿using Pinicules.Domain.DTOs;
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
        private const int PAGE_SIZE = 10;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public ActionResult Search(string searchTerm = "")
        {
            var model = new MoviesSearchResult() { Items = new List<MovieSearchItem>() };

            return View(model);
        }

        public PartialViewResult SearchMovies(int page, string searchTerm = "")
        {
            List<MovieDTO> movies = moviesService.GetMovies(searchTerm, PAGE_SIZE + 1, page, PAGE_SIZE);

            var model = new MoviesSearchResult() 
            { 
                Items = movies.Take(PAGE_SIZE).Select(m => new MovieSearchItem { Id = m.Id, Title = m.Title, Image = m.Image }).ToList()
            };

            if (movies.Count > PAGE_SIZE)
                model.LoadMore = true;

            model.NextPage = page + 1;

            return PartialView(model);
        }
    }
}