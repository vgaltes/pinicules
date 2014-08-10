using Pinicules.Domain.DTOs;
using System.Collections.Generic;

namespace Pinicules.Domain.Services
{
    public interface IMoviesService
    {
        void AddNewMovie(int movieId, string title);

        List<MovieDTO> GetMovies(string searchTerm, int numItems, int page, int pageSize);

        MovieDTO GetMovie(int movieId);

        List<MovieDTO> LookupMovies(string searchTerm);

        void AddCategoryToMovie(string category, int idMovie);
    }
}
