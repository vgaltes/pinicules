using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pinicules.TestBuilders;
using AssertMVC;
using System.Web.Mvc;
using Pinicules.Presentation.Models;
using Moq;
using Pinicules.Domain.Repositories;
using Pinicules.Data.Entities;
using System.Collections.Generic;
using Pinicules.Domain.Services;
using Pinicules.Domain.DTOs;

namespace Pinicules.Presentation.Tests
{
    [TestClass]
    public class SearchMoviesTests
    {
        [TestMethod]
        public void SearchWillGetAListOfCategoriesFromMoviesService()
        {
            var mockMoviesService = new Mock<IMoviesService>();
            var categories = new List<CategoryDTO>{
                new CategoryDTO{Name = "Drama"},
                new CategoryDTO { Name = "Action"}};

            mockMoviesService.Setup(mr => mr.GetCategories()).Returns(categories);

            var moviesController = new MoviesControllerBuilder()
                                        .WithMovieService(mockMoviesService.Object)
                                        .Build();

            var result = moviesController.Search();

            var model = result.ShouldBe<ViewResult>().WithModel().OfType<SearchModel>();
            Assert.IsTrue(model.Categories.Count > 0);
            mockMoviesService.Verify(mr => mr.GetCategories());
        }
    }
}
