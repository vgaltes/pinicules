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

        public List<MovieDTO> GetMovies(int numItems, int page, int pageSize)
        {
            var movies = this.moviesRepository.GetMovies(numItems, page, pageSize);
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
    }
}
