using Pinicules.Domain.DTOs;
using System.Collections.Generic;

namespace Pinicules.Domain.Repositories
{
    public interface ITmdbRepository
    {
        MovieDTO GetMovieInformation(MovieDTO movie);

        MovieDTO GetMovieInformation(int movieId);

        List<MovieDTO> GetMovies(string searchTerm);
    }
}
