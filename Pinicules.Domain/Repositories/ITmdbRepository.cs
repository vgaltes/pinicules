using Pinicules.Domain.DTOs;
namespace Pinicules.Domain.Repositories
{
    public interface ITmdbRepository
    {
        MovieDTO GetMovieInformation(MovieDTO movie);

        MovieDTO GetMovieInformation(int movieId);
    }
}
