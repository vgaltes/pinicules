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

        public void GetMovies()
        {
            var movies = this.moviesRepository.GetMovies();

            if (movies != null)
            {
                foreach (var movie in movies)
                {
                    tmdbRepository.GetMovieInformation(movie);
                }
            }
        }
    }
}
