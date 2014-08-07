﻿using System;
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
        MoviesContext moviesContext;

        public MoviesRepository(MoviesContext moviesContext)
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
                this.moviesContext.SaveChanges();
            }
        }
    }
}