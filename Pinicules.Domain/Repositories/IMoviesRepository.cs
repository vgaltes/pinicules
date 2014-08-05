using Pinicules.Domain.DTOs;
using System.Collections.Generic;

namespace Pinicules.Domain.Repositories
{
    public interface IMoviesRepository
    {
        List<MovieDTO> GetMovies(string searchTerm, int numItems, int page, int pageSize);

        MovieDTO GetMovie(int movieId);

        object Add(int p1, string p2);
    }
}
