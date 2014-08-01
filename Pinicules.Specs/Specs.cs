using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using AssertMVC;

namespace Pinicules.Specs
{
    [TestClass]
    public class Specs
    {
        [TestMethod]
        public void If_I_Have_Ten_Movies_In_DB_Controller_Returns_A_Model_With_Ten_Items()
        {
            IMoviesRepository moviesRepository = new InMemoryMoviesRepository();
            IMoviesService moviesService = new moviesService(moviesRepository);
            var moviesController = new MoviesController(moviesService);

            ActionResult result = moviesController.Index();

            MoviesSearchResult model = result.ShouldBe<ViewResult>().WithModel().OfType<MoviesSearchResult>().Object();
            Assert.AreEqual(10, model.Items.Length());
        }
    }
}
