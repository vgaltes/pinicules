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
            var model = new MoviesSearchResult() { Items = new List<MovieSearchItem>(), SearchTerm = searchTerm };

            return View(model);
        }

        public PartialViewResult SearchMovies(int page, string searchTerm = "")
        {
            List<MovieDTO> movies = moviesService.GetMovies(searchTerm, PAGE_SIZE + 1, page, PAGE_SIZE);

            var model = new MoviesSearchResult() 
            { 
                Items = movies.Take(PAGE_SIZE).Select(m => new MovieSearchItem { Id = m.Id, Title = m.Title, Image = m.Image }).ToList(),
                SearchTerm = searchTerm,
                NextPage = page + 1
            };

            if (movies.Count > PAGE_SIZE)
                model.LoadMore = true;

            return PartialView(model);
        }

        public ActionResult Movie(int id, string previousSearch = "")
        {
            MovieItem movie = new MovieItem(moviesService.GetMovie(id), previousSearch);

            return View(movie);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NewMovie newMovie)
        {
            moviesService.AddNewMovie(newMovie.MovieId, newMovie.Title);
            return RedirectToAction("Movie", new { id = newMovie });
        }

        public ActionResult LookupMovies(string searchTerm)
        {
            var items = moviesService.LookupMovies(searchTerm);

            var model = new LookupMoviesResult();
            model.Items = items.Select(i => new LookupMovieItem { Id = i.Id, Image = i.Image, Title = i.Title }).ToList();

            return PartialView(model);
        }
    }
}