using Pinicules.Domain.Repositories;
using Pinicules.Domain.Services;
using Pinicules.Data.Repositories;
using Pinicules.Presentation.Controllers;

namespace Pinicules.TestBuilders
{
    public class MoviesControllerBuilder
    {
        IMoviesRepository moviesRepository;
        ITmdbRepository tmdbRepository;

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
            var moviesService = new MoviesService(moviesRepository, tmdbRepository);
            return new MoviesController(moviesService);
        }
    }
}
