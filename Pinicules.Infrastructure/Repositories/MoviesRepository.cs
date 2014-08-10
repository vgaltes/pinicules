using System;
using System.Collections.Generic;
using System.Linq;
using Pinicules.Data.Entities;
using Pinicules.Data.Infrastructure;
using Pinicules.Domain.DTOs;
using Pinicules.Domain.Repositories;

namespace Pinicules.Data.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IMoviesContext moviesContext;

        public MoviesRepository(IMoviesContext moviesContext)
        {
            this.moviesContext = moviesContext;
        }
 
        public List<MovieDTO> GetMovies(string searchTerm, int numItems, int page, int pageSize)
        {
            Func<Movie, bool> filter;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                filter = new Func<Movie, bool>(m => true);
            }
            else
            {
                filter = new Func<Movie,bool>(m => m.Title.ToLower().Contains(searchTerm.ToLower() ));
            }

            return this.moviesContext.Movies
                    .Where(filter) 
                    .OrderBy(m=>m.Title)
                    .Skip((page - 1) * pageSize)
                    .Take(numItems)
                    .Select(m => new MovieDTO{Id = m.Id, Title = m.Title})
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
                    movie.Categories.Add(new Category { IdMovie = idMovie, Name = category });
                    this.moviesContext.Save();
                }
            }
        }
    }
}