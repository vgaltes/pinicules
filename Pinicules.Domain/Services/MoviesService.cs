using Pinicules.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinicules.Domain.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            this.moviesRepository = moviesRepository;
        }
    }
}
