using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Pinicules.Domain.Repositories;
using Pinicules.Domain.Services;

namespace Pinicules.Domain.Tests
{
    [TestClass]
    public class MoviesServiceTests
    {
        [TestMethod]
        public void WhenGettingMoviesShouldCallToMoviesRepository()
        {
            var movieRepositoryMock = new Mock<IMoviesRepository>();

            var moviesService = new MoviesService(movieRepositoryMock.Object, null);

            moviesService.GetMovies();

            movieRepositoryMock.Verify(mr => mr.GetMovies(), Times.Once());
        }
    }
}
