using Pinicules.Domain.DTOs;
using Pinicules.Domain.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Pinicules.Infrastructure.Repositories
{
    public class InMemoryMoviesRepository : IMoviesRepository
    {
        private List<MovieDTO> movies = new List<MovieDTO>{
                new MovieDTO(){Id = 100402, Title="Captain America: The Winter Soldier"},
                new MovieDTO(){Id = 102382, Title="The Amazing SpiderMan 2"},
                new MovieDTO(){Id = 157350, Title="Divergente"},
                new MovieDTO(){Id = 193610, Title="Mujeres al ataque"},
                new MovieDTO(){Id = 138103, Title="Expendables 3"},
                new MovieDTO(){Id = 119450, Title="Planeta simios"},
                new MovieDTO(){Id = 86834, Title="Noe"},
                new MovieDTO(){Id = 127585, Title="x-men"},
                new MovieDTO(){Id = 240832, Title="Lucy"},
                new MovieDTO(){Id = 172385, Title="RIO 2"},
                new MovieDTO(){Id = 62241, Title="Long way down"},
                new MovieDTO(){Id = 210024, Title="An adventure in space and dime"},
                new MovieDTO(){Id = 1771, Title="Capitan America"},
                new MovieDTO(){Id = 152737, Title="Agosto"},
                new MovieDTO(){Id = 157353, Title="Transcendence"}
            };

        public List<MovieDTO> GetMovies(string searchTerm, int numItems, int page, int pageSize)
        {
            return movies
                    .Where(m => m.Title.ToLowerInvariant().Contains(searchTerm.ToLowerInvariant())) 
                    .Skip((page - 1) * pageSize)
                    .Take(numItems).ToList();
        }

        public void Add(int movieId, string title)
        {
            throw new NotImplementedException();
        }
    }
}
