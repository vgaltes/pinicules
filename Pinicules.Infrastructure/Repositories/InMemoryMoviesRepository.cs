﻿using Pinicules.Domain.DTOs;
using Pinicules.Domain.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Pinicules.Data.Repositories
{
    public class InMemoryMoviesRepository : IMoviesRepository
    {

        private List<CategoryDTO> categories = new List<CategoryDTO>{
            new CategoryDTO{Name = "Action"}, 
            new CategoryDTO{Name = "Drama"}, 
            new CategoryDTO{Name = "History"}, 
            new CategoryDTO{Name = "Comedy"}, 
            new CategoryDTO{Name = "Cartoon"}, 
            new CategoryDTO{Name = "Thriller"}
        };

        private List<MovieDTO> movies = new List<MovieDTO>{
                new MovieDTO(){Id = 100402, Title="Captain America: The Winter Soldier", Categories = new List<CategoryDTO>() { new CategoryDTO{Name = "Action"}}},
                new MovieDTO(){Id = 102382, Title="The Amazing SpiderMan 2", Categories = new List<CategoryDTO>() { new CategoryDTO{Name = "Action"}}},
                new MovieDTO(){Id = 157350, Title="Divergente", Categories = new List<CategoryDTO>() { new CategoryDTO{Name = "Comedy"}}},
                new MovieDTO(){Id = 193610, Title="Mujeres al ataque", Categories = new List<CategoryDTO>() { new CategoryDTO{Name = "Comedy"}}},
                new MovieDTO(){Id = 138103, Title="Expendables 3", Categories = new List<CategoryDTO>() { new CategoryDTO{Name = "Action"}}},
                new MovieDTO(){Id = 119450, Title="Planeta simios", Categories = new List<CategoryDTO>() { new CategoryDTO{Name = "Action"}}},
                new MovieDTO(){Id = 86834, Title="Noe", Categories = new List<CategoryDTO>() { new CategoryDTO{Name = "History"}}},
                new MovieDTO(){Id = 127585, Title="x-men", Categories = new List<CategoryDTO>() { new CategoryDTO{Name = "Action"}}},
                new MovieDTO(){Id = 240832, Title="Lucy", Categories = new List<CategoryDTO>() { new CategoryDTO{Name = "Comedy"}}},
                new MovieDTO(){Id = 172385, Title="RIO 2", Categories = new List<CategoryDTO>() { new CategoryDTO{Name = "Cartoon"}}},
                new MovieDTO(){Id = 62241, Title="Long way down", Categories = new List<CategoryDTO>() { new CategoryDTO{Name = "Drama"}}},
                new MovieDTO(){Id = 210024, Title="An adventure in space and dime", Categories = new List<CategoryDTO>() { new CategoryDTO{Name = "Thriller"}}},
                new MovieDTO(){Id = 1771, Title="Capitan America", Categories = new List<CategoryDTO>() { new CategoryDTO{Name = "Action"}}},
                new MovieDTO(){Id = 152737, Title="Agosto", Categories = new List<CategoryDTO>() { new CategoryDTO{Name = "Thriller"}}},
                new MovieDTO(){Id = 157353, Title="Transcendence", Categories = new List<CategoryDTO>() { new CategoryDTO{Name = "Comedy"}}}
            };

        public List<MovieDTO> GetMovies(string searchTerm, string category, int numItems, int page, int pageSize)
        {
            return movies
                    .Where(m => m.Title.ToLowerInvariant().Contains(searchTerm.ToLowerInvariant()))
                    //.Where((m => !categories.Any() ? true : m.Categories.Intersect(categories).Any()))
                    .Where(m => string.IsNullOrWhiteSpace(category) ? true : m.Categories.Any(c => c.Name == category))
                    .Skip((page - 1) * pageSize)
                    .Take(numItems).ToList();
        }

        public void Add(int movieId, string title)
        {
            var movie = new MovieDTO { Id = movieId, Title = title };

            movies.Add(movie);
        }


        public void AddCategoryToMovie(string category, int idMovie)
        {

        }


        public List<CategoryDTO> GetCategoriesFromMovie(int movieId)
        {
            return movies.Find(m => m.Id == movieId).Categories;
        }


        public void RemoveCategoryFromMovie(string category, int idMovie)
        {
        }


        public List<CategoryDTO> GetCategories()
        {
            return categories;
        }
    }
}
