using Pinicules.Domain.DTOs;
using System.Collections.Generic;

namespace Pinicules.Domain.Services
{
    public interface IMoviesService
    {
        List<MovieDTO> GetMovies(string searchTerm, int numItems, int page, int pageSize);
    }
}
