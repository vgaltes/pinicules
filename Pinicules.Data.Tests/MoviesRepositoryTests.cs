using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pinicules.Data.Infrastructure;
using Pinicules.Data.Repositories;
using Pinicules.Data.Tests.Initializers;

namespace Pinicules.Data.Tests
{
    [TestClass]
    public class MoviesRepositoryTests
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            Database.SetInitializer(new MoviesInitializer());
        }

        MoviesRepository moviesRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            var moviesContext = new MoviesContext();
            moviesRepository = new MoviesRepository(moviesContext);
        }

        [TestMethod]
        public void TestRetrievingLessElementsThanPageSize()
        {
            var movies = moviesRepository.GetMovies(string.Empty, string.Empty, 8, 1, 10);

            Assert.AreEqual(8, movies.Count);
        }

        [TestMethod]
        public void TestRetrievingMoreElementsThanPageSize()
        {
            var movies = moviesRepository.GetMovies(string.Empty, string.Empty, 11, 1, 10);

            Assert.AreEqual(11, movies.Count);
        }

        [TestMethod]
        public void TestPagination()
        {
            var movies = moviesRepository.GetMovies(string.Empty, string.Empty, 11, 2, 10);

            Assert.AreEqual(5, movies.Count);
        }

        [TestMethod]
        public void TestFilter()
        {
            var movies = moviesRepository.GetMovies("spider", string.Empty, 11, 1, 10);

            Assert.AreEqual(1, movies.Count);
        }

        [TestMethod]
        public void TestFilterByCategory()
        {
            var movies = moviesRepository.GetMovies("", "Drama", 11, 1, 10);
            Assert.AreEqual(1, movies.Count);
            Assert.AreEqual("Long way down", movies[0].Title);
        }

        [TestMethod]
        public void TestAdd()
        {
            moviesRepository.Add(65, "new movie");

            var movies = moviesRepository.GetMovies("", string.Empty, 20, 1, 10);

            Assert.AreEqual(16, movies.Count);

            movies = moviesRepository.GetMovies("movie", string.Empty, 20, 1, 10);
            Assert.AreEqual(1, movies.Count);
            Assert.AreEqual(65, movies[0].Id);
            Assert.AreEqual("new movie", movies[0].Title);
        }
    }
}