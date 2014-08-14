using Pinicules.Domain.DTOs;
using System.Collections.Generic;

namespace Pinicules.Domain.Repositories
{
    public interface IMoviesRepository
    {
        List<MovieDTO> GetMovies(string searchTerm, List<string> categories, int numItems, int page, int pageSize);

        void Add(int movieId, string title);

        void AddCategoryToMovie(string category, int idMovie);

        List<string> GetCategoriesFromMovie(int movieId);

        void RemoveCategoryFromMovie(string category, int idMovie);

        List<string> GetCategories();
    }
}