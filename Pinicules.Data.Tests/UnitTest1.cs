using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pinicules.Data.Repositories;

namespace Pinicules.Data.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Retrieving8ElementsShouldReturnTheFirst8Elements()
        {
            var moviesRepository = new MoviesRepository();

            var movies = moviesRepository.GetMovies(string.Empty, 8, 1, 10);

            Assert.AreEqual(8, movies.Count);
        }
    }
}