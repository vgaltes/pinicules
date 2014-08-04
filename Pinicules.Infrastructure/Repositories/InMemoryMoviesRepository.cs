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
                new MovieDTO(){Id = 100402},
                new MovieDTO(){Id = 102382},
                new MovieDTO(){Id = 157350},
                new MovieDTO(){Id = 193610},
                new MovieDTO(){Id = 138103},
                new MovieDTO(){Id = 119450},
                new MovieDTO(){Id = 86834},
                new MovieDTO(){Id = 127585},
                new MovieDTO(){Id = 240832},
                new MovieDTO(){Id = 172385},
                new MovieDTO(){Id = 62241},
                new MovieDTO(){Id = 210024},
                new MovieDTO(){Id = 1771},
                new MovieDTO(){Id = 152737},
                new MovieDTO(){Id = 157353}
            };

        public List<MovieDTO> GetMovies(int pageSize)
        {
            return movies.Take(pageSize).ToList();
        }
    }
}
