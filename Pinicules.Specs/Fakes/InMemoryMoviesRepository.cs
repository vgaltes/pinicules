using Pinicules.Domain.DTOs;
using Pinicules.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Pinicules.Specs.Fakes
{
    public class InMemoryMoviesRepository : IMoviesRepository
    {
        public List<MovieDTO> GetMovies()
        {
            throw new NotImplementedException();
        }
    }
}
