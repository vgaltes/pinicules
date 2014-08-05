using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pinicules.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AssertMVC;
using Pinicules.Domain.DTOs;

namespace Pinicules.Specs
{
    [TestClass]
    public class MovieSpecs
    {
        [TestMethod]
        public void When_Retrieving_A_Movie_Should_Get_The_MovieItem_Filled()
        {
            var moviesController = new MoviesControllerBuilder()
                                        .WithInMemoryMoviesRepository()
                                        .WithTmdbRepository()
                                        .Build();

            var result = moviesController.Movie(100402);

            MovieDTO model = result.ShouldBe<ViewResult>().WithModel().OfType<MovieDTO>();
            Assert.AreEqual("Capitán América: El soldado de invierno", model.Title);
            Assert.AreEqual(19, model.Actors.Count);
            Assert.AreEqual(2, model.Directors.Count);
        }
    }
}
