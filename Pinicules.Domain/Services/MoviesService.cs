using Pinicules.Domain.DTOs;
using Pinicules.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<MovieDTO> GetMovies(int pageSize)
        {
            var movies = this.moviesRepository.GetMovies(pageSize);
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
