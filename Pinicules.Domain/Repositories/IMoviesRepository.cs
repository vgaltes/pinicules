using Pinicules.Domain.DTOs;
using System.Collections.Generic;

namespace Pinicules.Domain.Repositories
{
    public interface IMoviesRepository
    {
        List<MovieDTO> GetMovies(string searchTerm, string category, int numItems, int page, int pageSize);

        void Add(int movieId, string title);

        void AddCategoryToMovie(string category, int idMovie);

        List<CategoryDTO> GetCategoriesFromMovie(int movieId);

        void RemoveCategoryFromMovie(string category, int idMovie);

        List<CategoryDTO> GetCategories();
    }
}