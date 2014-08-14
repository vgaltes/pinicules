using Pinicules.Domain.DTOs;
using Pinicules.Domain.Repositories;
using System.Collections.Generic;

namespace Pinicules.Domain.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository moviesRepository;

        private readonly ITmdbRepository tmdbRepository;

        public MoviesService(IMoviesRepository moviesRepository, ITmdbRepository tmdbRepository)
        {
            this.moviesRepository = moviesRepository;

            this.tmdbRepository = tmdbRepository;
        }

        public List<MovieDTO> GetMovies(string searchTerm, List<string> categories, int numItems, int page, int pageSize)
        {
            var movies = this.moviesRepository.GetMovies(searchTerm, categories, numItems, page, pageSize);
            var moviesFilled = new List<MovieDTO>();

            if (movies != null)
            {
                foreach (var movie in movies)
                {
                    var movieDto = new MovieDTO();
                    movieDto.Id = movie.Id;
                    movieDto = tmdbRepository.GetMovieInformation(movie);
                    moviesFilled.Add(movieDto);
                }
            }

            return moviesFilled;
        }

        public MovieDTO GetMovie(int movieId)
        {
            MovieDTO movie = tmdbRepository.GetMovieInformation(movieId);
            movie.Categories = moviesRepository.GetCategoriesFromMovie(movieId);
            return movie;
        }

        public void AddNewMovie(int movieId, string title)
        {
            moviesRepository.Add(movieId, title);
        }

        public List<MovieDTO> LookupMovies(string searchTerm)
        {
            return tmdbRepository.LookupMovies(searchTerm);
        }

        public void AddCategoryToMovie(string category, int idMovie)
        {
            moviesRepository.AddCategoryToMovie(category, idMovie);
        }

        public void RemoveCategoryFromMovie(string category, int idMovie)
        {
            moviesRepository.RemoveCategoryFromMovie(category, idMovie);
        }

        public List<string> GetCategories()
        {
            throw new System.NotImplementedException();
        }
    }
}
