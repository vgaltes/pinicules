﻿using AssertMVC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pinicules.Presentation.Models;
using Pinicules.TestBuilders;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Generic;

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

            MovieItem model = result.ShouldBe<ViewResult>().WithModel().OfType<MovieItem>();
            Assert.AreEqual("Capitán América: El Soldado de Invierno", model.Title);
            Assert.AreEqual(19, model.Actors.Count);
            Assert.AreEqual(2, model.Directors.Count);
        }

        [TestMethod]
        public void When_Adding_A_Movie_Should_Add_To_Infranstructure()
        {
            var moviesController = new MoviesControllerBuilder()
                                        .WithInMemoryMoviesRepository()
                                        .WithTmdbRepository()
                                        .Build();

            var request = new Mock<HttpRequestBase>(MockBehavior.Strict);
            request.SetupGet(x => x.ApplicationPath).Returns("/");
            request.SetupGet(x => x.ServerVariables).Returns(new System.Collections.Specialized.NameValueCollection());
            request.SetupGet(x => x.HttpMethod).Returns("POST");
            var response = new Mock<HttpResponseBase>(MockBehavior.Strict);

            var context = new Mock<HttpContextBase>(MockBehavior.Strict);
            context.SetupGet(x => x.Request).Returns(request.Object);
            context.SetupGet(x => x.Response).Returns(response.Object);

            moviesController.ControllerContext = new ControllerContext(context.Object, new RouteData(), moviesController);

            moviesController.Add(new NewMovie(124905, "Godzilla"));

            ActionResult result = moviesController.SearchMovies(2, string.Empty);

            MoviesSearchResult model = result.ShouldBe<PartialViewResult>().WithModel().OfType<MoviesSearchResult>();
            Assert.AreEqual(6, model.Items.Count);
        }
    }
}
