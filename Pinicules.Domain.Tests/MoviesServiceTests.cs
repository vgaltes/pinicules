using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pinicules.Domain.DTOs;
using Pinicules.Domain.Repositories;
using Pinicules.Domain.Services;
using System.Collections.Generic;

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

        [TestMethod]
        public void ForEachMovieRetrievedShouldCallToTmdbRepositoryGetMovieInformation()
        {
            var movieRepositoryMock = new Mock<IMoviesRepository>();
            var movies = new List<MovieDTO>
            {
                new MovieDTO(1, "comments", 4.5f),
                new MovieDTO(2, "comments", 3.5f),
            };

            movieRepositoryMock.Setup(mr => mr.GetMovies()).Returns(movies);

            var tmdbRepositoryMock = new Mock<ITmdbRepository>();

            var moviesService = new MoviesService(movieRepositoryMock.Object, null);

            moviesService.GetMovies();

            tmdbRepositoryMock.Verify(tmdb => tmdb.GetMovieInformation(), Times.Exactly(2));
            
        }
    }
}
