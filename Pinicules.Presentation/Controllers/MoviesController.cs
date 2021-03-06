﻿using Pinicules.Domain.DTOs;
using Pinicules.Domain.Services;
using Pinicules.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace Pinicules.Presentation.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;
        private const int PAGE_SIZE = 10;


        public Func<MovieDTO, string> GetConversionForMovieSearchItem()
        {
            return new Func<MovieDTO, string>(src =>
            {
                var image = string.IsNullOrWhiteSpace(src.Image) ? UrlHelper.GenerateContentUrl("~/Content/noMovieImage.png", this.HttpContext)
                            : src.Image;
                return image;
            });
        }

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;

            Mapper.CreateMap<MovieDTO, MovieSearchItem>()
                .ForMember(m => m.Image,
                    opt => opt.MapFrom(src => GetConversionForMovieSearchItem()(src)));
        }

        public ActionResult Search(string searchTerm = "")
        {

            var model = new SearchModel();
            model.Categories = this.moviesService.GetCategories().Select(c => c.Name).ToList();

            return View(model);
        }

        public PartialViewResult SearchMovies(int page, string category, string searchTerm = "")
        {
            List<MovieDTO> movies = moviesService.GetMovies(searchTerm, category, PAGE_SIZE + 1, page, PAGE_SIZE);

            var model = new MoviesSearchResult() 
            { 
                Items = movies.Take(PAGE_SIZE).Select(m => Mapper.Map<MovieDTO, MovieSearchItem>(m)).ToList(),
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

        [HttpPost]
        public ActionResult CategoryAdd(int idMovie, string category)
        {
            moviesService.AddCategoryToMovie(category, idMovie);
            return new HttpStatusCodeResult(200);
        }

        [HttpPost]
        public ActionResult CategoryRemove(int idMovie, string category)
        {
            moviesService.RemoveCategoryFromMovie(category, idMovie);
            return new HttpStatusCodeResult(200);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NewMovie newMovie)
        {
            moviesService.AddNewMovie(newMovie.MovieId, newMovie.Title);
            return RedirectToAction("Movie", new { id = newMovie.MovieId });
        }

        public ActionResult LookupMovies(string searchTerm)
        {
            var items = moviesService.LookupMovies(searchTerm);

            var model = new LookupMoviesResult();
            model.Items = items.Select(i => new MovieSearchItem
            {
                Id = i.Id,
                Image = (string.IsNullOrWhiteSpace(i.Image) ? Url.Content("~/Content/noMovieImage.png") : i.Image),
                Title = i.Title
            }).ToList();

            //model.Items = Mapper.Map<List<MovieDTO>, List<MovieSearchItem>>(items);

            return PartialView(model);
        }
    }
}