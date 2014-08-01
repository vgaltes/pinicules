using Pinicules.Domain.DTOs;
using Pinicules.Domain.Repositories;
using System.Linq;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;

namespace Pinicules.Infrastructure.Repositories
{
    public class TmdbRepository : ITmdbRepository
    {
        private string API_KEY = "16ccc0e8d1eb827495441b96b448b02f";
        TMDbClient client;

        public TmdbRepository()
        {
            client = new TMDbClient(API_KEY);
            client.GetConfig();
        }

        public MovieDTO GetMovieInformation(MovieDTO movieDto)
        {
            Movie movie = client.GetMovie(movieDto.Id);
            TMDbLib.Objects.Movies.Credits credits = client.GetMovieCredits(movieDto.Id);

            movieDto.Summary = movie.Overview;
            movieDto.Title = movie.Title;
            movieDto.Directors = credits.Crew.Where(c => c.Job == "Director").Select(c => c.Name).ToList();
            movieDto.Actors = credits.Cast.Select(c => c.Name).ToList();

            return movieDto;
        }


        public MovieDTO GetMovieTitle(MovieDTO movieDto)
        {
            Movie movie = client.GetMovie(movieDto.Id);

            movieDto.Title = movie.Title;

            return movieDto;
        }
    }
}
