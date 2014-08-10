using Pinicules.Domain.DTOs;
using System.Collections.Generic;

namespace Pinicules.Domain.Repositories
{
    public interface IMoviesRepository
    {
        List<MovieDTO> GetMovies(string searchTerm, int numItems, int page, int pageSize);

        void Add(int movieId, string title);

        void AddCategoryToMovie(string category, int idMovie);

        List<string> GetCategoriesFromMovie(int movieId);

        object RemoveCategoryFromMovie(string category, int idMovie);
    }
}