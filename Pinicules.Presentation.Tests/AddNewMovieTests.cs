using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pinicules.TestBuilders;
using AssertMVC;
using System.Web;
using System.Web.Mvc;
using Pinicules.Presentation.Models;

namespace Pinicules.Presentation.Tests
{
    [TestClass]
    public class AddNewMovieTests
    {
        [TestMethod]
        public void AddShouldReturnAView()
        {
            var moviesController = new MoviesControllerBuilder()
                                        .WithInMemoryMoviesRepository()
                                        .WithTmdbRepository()
                                        .Build();

            ActionResult result = moviesController.Add();

            result.ShouldBe<ViewResult>();
        }

        [TestMethod]
        public void LookupMoviesShouldReturnTheMovie()
        {
            var moviesController = new MoviesControllerBuilder()
                                        .WithInMemoryMoviesRepository()
                                        .WithTmdbRepository()
                                        .Build();

            ActionResult result = moviesController.LookupMovies("el milagro de p tinto");

            var model = result.ShouldBe<PartialViewResult>().WithModel().OfType<LookupMoviesResult>();

            Assert.AreEqual(1, model.Items.Count);
        }
    }
}
