using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pinicules.Domain.DTOs;
using Pinicules.Domain.Repositories;
using Pinicules.Domain.Services;
using System.Collections.Generic;
using FluentAssertions;

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

            moviesService.GetMovies("", new List<string>(), 1, 1, 10);

            movieRepositoryMock.Verify(mr => mr.GetMovies("", new List<string>(), 1, 1, 10), Times.Once());
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

            movieRepositoryMock.Setup(mr => mr.GetMovies("", new List<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(movies);

            var tmdbRepositoryMock = new Mock<ITmdbRepository>();

            var moviesService = new MoviesService(movieRepositoryMock.Object, tmdbRepositoryMock.Object);

            moviesService.GetMovies("", new List<string>(), movies.Count, 1, 10);

            tmdbRepositoryMock.Verify(tmdb => tmdb.GetMovieInformation(It.IsAny<MovieDTO>()), Times.Exactly(2));

        }

        [TestMethod]
        public void GetMoviesShouldReturnAnArrayOfMoviesFilled()
        {
            var movieRepositoryMock = new Mock<IMoviesRepository>();
            var dbMovie1 = new MovieDTO(1, "comments1", 4.5f);
            var dbMovie2 = new MovieDTO(2, "comments2", 3.5f);

            movieRepositoryMock.Setup(mr => mr.GetMovies("", new List<string>(), 2, 1, 10)).Returns(new List<MovieDTO> { dbMovie1, dbMovie2 });

            var tmdbRepositoryMock = new Mock<ITmdbRepository>();

            var tmdbMovie1 = new MovieDTO() { Id = 1, Title = "Title 1", Image = "url1" };
            var tmdbMovie2 = new MovieDTO() { Id = 2, Title = "Title 2", Image = "url2" };

            tmdbRepositoryMock.Setup(tmdb => tmdb.GetMovieInformation(dbMovie1)).Returns(tmdbMovie1);
            tmdbRepositoryMock.Setup(tmdb => tmdb.GetMovieInformation(dbMovie2)).Returns(tmdbMovie2);

            var moviesService = new MoviesService(movieRepositoryMock.Object, tmdbRepositoryMock.Object);

            var resultMovies = moviesService.GetMovies("", new List<string>(), 2, 1, 10);

            Assert.AreEqual(2, resultMovies.Count);
            Assert.AreEqual("Title 1", resultMovies[0].Title);
            Assert.IsFalse(string.IsNullOrEmpty(resultMovies[0].Image));
            Assert.AreEqual(1, resultMovies[0].Id);
        }

        [TestMethod]
        public void GetMovieShouldCallToTmdbRepository()
        {
            var movieRepositoryMock = new Mock<IMoviesRepository>();
            var tmdbRepositoryMock = new Mock<ITmdbRepository>();

            var tmdbMovie1 = new MovieDTO() { Id = 1, Title = "Title 1", Image = "url1" };

            tmdbRepositoryMock.Setup(tmdb => tmdb.GetMovieInformation(1)).Returns(tmdbMovie1);

            var moviesService = new MoviesService(movieRepositoryMock.Object, tmdbRepositoryMock.Object);

            MovieDTO movie = moviesService.GetMovie(1);

            movie.ShouldBeEquivalentTo(tmdbMovie1);
        }

        [TestMethod]
        public void AddMovieShouldCallMoviesRepository()
        {
            var movieRepositoryMock = new Mock<IMoviesRepository>();
            var tmdbRepositoryMock = new Mock<ITmdbRepository>();

            var moviesService = new MoviesService(movieRepositoryMock.Object, tmdbRepositoryMock.Object);

            moviesService.AddNewMovie(1, "Title 1");

            movieRepositoryMock.Verify(mrm => mrm.Add(1, "Title 1"));
        }

        [TestMethod]
        public void LookupMoviesShouldCallTmdbRepository()
        {
            var movieRepositoryMock = new Mock<IMoviesRepository>();
            var tmdbRepositoryMock = new Mock<ITmdbRepository>();

            var moviesService = new MoviesService(movieRepositoryMock.Object, tmdbRepositoryMock.Object);

            moviesService.LookupMovies("search term");

            tmdbRepositoryMock.Verify(t => t.LookupMovies("search term"));
        }

        [TestMethod]
        public void AddCategoryShoulCallMoviesRepository()
        {
            var movieRepositoryMock = new Mock<IMoviesRepository>();
            var tmdbRepositoryMock = new Mock<ITmdbRepository>();

            var moviesService = new MoviesService(movieRepositoryMock.Object, tmdbRepositoryMock.Object);
            int idMovie = 1;
            string category = "category";

            moviesService.AddCategoryToMovie(category, idMovie);

            movieRepositoryMock.Verify(mrm => mrm.AddCategoryToMovie(category, idMovie));
        }

        [TestMethod]
        public void RemoveCategoryShoulCallMoviesRepository()
        {
            var movieRepositoryMock = new Mock<IMoviesRepository>();
            var tmdbRepositoryMock = new Mock<ITmdbRepository>();

            var moviesService = new MoviesService(movieRepositoryMock.Object, tmdbRepositoryMock.Object);
            int idMovie = 1;
            string category = "category";

            moviesService.RemoveCategoryFromMovie(category, idMovie);

            movieRepositoryMock.Verify(mrm => mrm.RemoveCategoryFromMovie(category, idMovie));
        }
    }
}
