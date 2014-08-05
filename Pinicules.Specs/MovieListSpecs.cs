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
    public class MovieListSpecs
    {
        MoviesController moviesController;

        [TestInitialize]
        public void TestInitialize()
        {
            moviesController = new MoviesControllerBuilder()
                                .WithInMemoryMoviesRepository()
                                .WithTmdbRepository()
                                .Build();
        }

        [TestMethod]
        public void If_I_Have_Ten_Movies_In_DB_Controller_Returns_A_Model_With_Ten_Items()
        {
            ActionResult result = moviesController.SearchMovies(1);

            MoviesSearchResult model = result.ShouldBe<PartialViewResult>().WithModel().OfType<MoviesSearchResult>();
            Assert.AreEqual(10, model.Items.Count);
        }

        [TestMethod]
        public void If_I_Have_More_Than_Ten_Movies_In_DB_Controller_Returns_A_Model_With_Load_More_Enabled()
        {
            ActionResult result = moviesController.SearchMovies(1);

            MoviesSearchResult model = result.ShouldBe<PartialViewResult>().WithModel().OfType<MoviesSearchResult>();
            Assert.IsTrue(model.LoadMore);
        }

        [TestMethod]
        public void Movies_Controller_Return_Items_Regarding_The_Actual_Page()
        {
            ActionResult result = moviesController.SearchMovies(2);

            MoviesSearchResult model = result.ShouldBe<PartialViewResult>().WithModel().OfType<MoviesSearchResult>();
            Assert.IsFalse(model.LoadMore);
            Assert.AreEqual(5, model.Items.Count);
            Assert.AreEqual(3, model.NextPage);
        }

        [TestMethod]
        public void When_Looking_For_Spiderman_Should_Return_One_Result()
        {
            ActionResult result = moviesController.SearchMovies(1, "Spiderman");

            MoviesSearchResult model = result.ShouldBe<PartialViewResult>().WithModel().OfType<MoviesSearchResult>();
            Assert.IsFalse(model.LoadMore);
            Assert.AreEqual(1, model.Items.Count);
        }
    }
}