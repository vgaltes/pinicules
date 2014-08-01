using Pinicules.Domain.DTOs;
using Pinicules.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Pinicules.Infrastructure.Repositories
{
    public class InMemoryMoviesRepository : IMoviesRepository
    {
        public List<MovieDTO> GetMovies()
        {
            return new List<MovieDTO>{
                new MovieDTO(){Id = 100402},
                new MovieDTO(){Id = 102382},
                new MovieDTO(){Id = 157350},
                new MovieDTO(){Id = 193610},
                new MovieDTO(){Id = 138103},
                new MovieDTO(){Id = 119450},
                new MovieDTO(){Id = 86834},
                new MovieDTO(){Id = 127585},
                new MovieDTO(){Id = 240832},
                new MovieDTO(){Id = 172385}
            };
        }
    }
}
