using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pinicules.Domain.DTOs;
using Pinicules.Domain.Repositories;

namespace Pinicules.Data.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        public List<MovieDTO> GetMovies(string searchTerm, int numItems, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Add(int movieId, string title)
        {
            throw new NotImplementedException();
        }
    }
}
