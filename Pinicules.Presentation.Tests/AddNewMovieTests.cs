using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pinicules.TestBuilders;
using AssertMVC;
using System.Web;
using System.Web.Mvc;

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
    }
}
