using Pinicules.Domain.Repositories;
using Pinicules.Domain.Services;
using Pinicules.Data.Repositories;
using Pinicules.Presentation.Controllers;
using Pinicules.Domain.DTOs;
using System.Collections.Generic;

namespace Pinicules.TestBuilders
{
    public class MoviesControllerBuilder
    {
        IMoviesRepository moviesRepository;
        ITmdbRepository tmdbRepository;
        IMoviesService moviesService;

        public MoviesControllerBuilder()
        {

        }

        public MoviesControllerBuilder WithInMemoryMoviesRepository()
        {
            moviesRepository = new InMemoryMoviesRepository();
            return this;
        }

        public MoviesControllerBuilder WithTmdbRepository()
        {
            tmdbRepository = new TmdbRepository();
            return this;
        }

        public MoviesController Build()
        {
            if (moviesService == null)
                moviesService = new MoviesService(moviesRepository, tmdbRepository);
            
            return new MoviesController(moviesService);
        }

        public MoviesControllerBuilder WithMovieService(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
            return this;
        }
    }
}
