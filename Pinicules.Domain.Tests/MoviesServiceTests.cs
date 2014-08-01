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

            var moviesService = new MoviesService(movieRepositoryMock.Object, tmdbRepositoryMock.Object);

            moviesService.GetMovies();

            tmdbRepositoryMock.Verify(tmdb => tmdb.GetMovieInformation(It.IsAny<MovieDTO>()), Times.Exactly(2));

        }

        [TestMethod]
        public void GetMoviesShouldReturnAnArrayOfMoviesFilled()
        {
            var movieRepositoryMock = new Mock<IMoviesRepository>();
            var dbMovie1 = new MovieDTO(1, "comments1", 4.5f);
            var dbMovie2 = new MovieDTO(2, "comments2", 3.5f);

            movieRepositoryMock.Setup(mr => mr.GetMovies()).Returns(new List<MovieDTO> { dbMovie1, dbMovie2 });

            var tmdbRepositoryMock = new Mock<ITmdbRepository>();
            var tmdbMovie1 = new MovieDTO()
            {
                Id = 1,
                Title = "Title 1"
            };
            var tmdbMovie2 = new MovieDTO()
            {
                Id = 2,
                Title = "Title 2"
            };

            tmdbRepositoryMock.Setup(tmdb => tmdb.GetMovieTitle(dbMovie1)).Returns(tmdbMovie1);
            tmdbRepositoryMock.Setup(tmdb => tmdb.GetMovieTitle(dbMovie2)).Returns(tmdbMovie2);

            var moviesService = new MoviesService(movieRepositoryMock.Object, tmdbRepositoryMock.Object);

            var resultMovies = moviesService.GetMovies();

            Assert.AreEqual(2, resultMovies.Count);
            Assert.AreEqual("Title 1", resultMovies[0].Title);
            Assert.AreEqual(1, resultMovies[0].Id);
        }
    }
}
