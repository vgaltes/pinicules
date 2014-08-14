using System;
using System.Collections.Generic;
using System.Linq;
using Pinicules.Data.Entities;
using Pinicules.Data.Infrastructure;
using Pinicules.Domain.DTOs;
using Pinicules.Domain.Repositories;
using AutoMapper;

namespace Pinicules.Data.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IMoviesContext moviesContext;

        public MoviesRepository(IMoviesContext moviesContext)
        {
            this.moviesContext = moviesContext;

            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<Category, CategoryDTO>();
        }
 
        public List<MovieDTO> GetMovies(string searchTerm, string category, int numItems, int page, int pageSize)
        {
            Func<Movie, bool> filter;
            Func<Movie, bool> categoriesFilter;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                filter = new Func<Movie, bool>(m => true);
            }
            else
            {
                filter = new Func<Movie,bool>(m => m.Title.ToLower().Contains(searchTerm.ToLower() ));
            }

            if ( string.IsNullOrWhiteSpace(category))
            {
                categoriesFilter = new Func<Movie, bool>(m => true);
            }
            else
            {
                categoriesFilter = new Func<Movie, bool>(m =>
                    m.Categories.Any(c => c.Name == category)
                );
            }

            return this.moviesContext.Movies.Include("Categories")
                    .Where(filter) 
                    .Where(categoriesFilter)
                    .OrderBy(m=>m.Title)
                    .Skip((page - 1) * pageSize)
                    .Take(numItems)
                    //.Select(m => new MovieDTO{
                    //    Id = m.Id, 
                    //    Title = m.Title, 
                    //    Categories = (m.Categories == null ? new List<string>() : m.Categories.Select(c => c.Name).ToList())})
                    .Select(m => Mapper.Map<MovieDTO>(m))
                    .ToList();
        }

        public void Add(int movieId, string title)
        {
            if (moviesContext.Movies.Find(movieId) == null)
            {
                this.moviesContext.Movies.Add(new Movie { Id = movieId, Title = title });
                this.moviesContext.Save();
            }
        }


        public void AddCategoryToMovie(string category, int idMovie)
        {
            Movie movie = moviesContext.Movies.Find(idMovie);

            if (movie != null)
            {
                if (!movie.Categories.Any(c => c.Name == category))
                {
                    movie.Categories.Add(new Category { Name = category });
                    this.moviesContext.Save();
                }
            }
        }


        public List<CategoryDTO> GetCategoriesFromMovie(int movieId)
        {
            Movie movie = moviesContext.Movies.Find(movieId);

            return movie.Categories.Select(c => Mapper.Map<CategoryDTO>(c)).ToList();
        }


        public void RemoveCategoryFromMovie(string category, int idMovie)
        {
            Movie movie = moviesContext.Movies.Find(idMovie);

            movie.Categories.Remove(movie.Categories.First(c => c.Name == category));

            this.moviesContext.Save();

            if (!moviesContext.Movies.Any(m => m.Categories.Any(c => c.Name == category))) 
            {
                var categoryToRemove = this.moviesContext.Categories.Find(category);
                this.moviesContext.Categories.Remove(categoryToRemove);
            }

            this.moviesContext.Save();
        }

        List<CategoryDTO> IMoviesRepository.GetCategories()
        {
            return moviesContext.Categories.Select(c => Mapper.Map<CategoryDTO>(c)).ToList();
        }
    }
}