﻿using AssertMVC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pinicules.Domain.Repositories;
using Pinicules.Domain.Services;
using Pinicules.Infrastructure.Repositories;
using Pinicules.Presentation.Controllers;
using Pinicules.Presentation.Models;
using System.Web.Mvc;

namespace Pinicules.Specs
{
    [TestClass]
    public class Specs
    {
        [TestMethod]
        public void If_I_Have_Ten_Movies_In_DB_Controller_Returns_A_Model_With_Ten_Items()
        {
            IMoviesRepository moviesRepository = new InMemoryMoviesRepository();
            ITmdbRepository tmdbRepository = new TmdbRepository();
            IMoviesService moviesService = new MoviesService(moviesRepository, tmdbRepository);
            var moviesController = new MoviesController(moviesService);

            ActionResult result = moviesController.Index();

            MoviesSearchResult model = result.ShouldBe<ViewResult>().WithModel().OfType<MoviesSearchResult>();
            Assert.AreEqual(10, model.Items.Count);
        }
    }
}
