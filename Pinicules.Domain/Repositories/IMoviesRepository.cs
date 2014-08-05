using Pinicules.Domain.DTOs;
using System.Collections.Generic;

namespace Pinicules.Domain.Repositories
{
    public interface IMoviesRepository
    {
        List<MovieDTO> GetMovies(int numItems, int page, int pageSize);
    }
}
