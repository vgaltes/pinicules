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

        public List<MovieDTO> GetMovies()
        {
            var movies = this.moviesRepository.GetMovies();
            var moviesFilled = new List<MovieDTO>();

            if (movies != null)
            {
                foreach (var movie in movies)
                {
                    moviesFilled.Add(tmdbRepository.GetMovieInformation(movie));
                }
            }

            return moviesFilled;
        }
    }
}
