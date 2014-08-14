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

namespace Pinicules.Presentation.Tests
{
    [TestClass]
    public class SearchMoviesTests
    {
        [TestMethod]
        public void SearchWillGetAListOfCategoriesFromMoviesService()
        {
            var mockMoviesRepository = new Mock<IMoviesRepository>();
            var categories = new List<Category>{new Category{Name="Drama"}, new Category{Name="Action"}};
            mockMoviesRepository.Setup(mr => mr.GetCategories()).Returns(categories);

            var moviesController = new MoviesControllerBuilder()
                                        .WithMemoryMoviesRepository(mockMoviesRepository.Object)
                                        .WithTmdbRepository()
                                        .Build();

            var result = moviesController.Search();

            var model = result.ShouldBe<ViewResult>().WithModel().OfType<SearchModel>();
            Assert.IsTrue(model.Categories.Count > 0);
            mockMoviesRepository.Verify(mr => mr.GetCategories());
        }
    }
}
