using Pinicules.Domain.DTOs;
using Pinicules.Domain.Repositories;

namespace Pinicules.Infrastructure.Repositories
{
    public class TmdbRepository : ITmdbRepository
    {
        public MovieDTO GetMovieInformation(MovieDTO movie)
        {
            return movie;
        }
    }
}
