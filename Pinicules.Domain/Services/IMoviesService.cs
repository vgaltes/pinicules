using Pinicules.Domain.DTOs;
using System.Collections.Generic;

namespace Pinicules.Domain.Services
{
    public interface IMoviesService
    {
        List<MovieDTO> GetMovies(int numItems, int page, int pageSize);
    }
}
