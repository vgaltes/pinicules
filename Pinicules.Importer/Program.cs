using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pinicules.Data.Infrastructure;
using Pinicules.Data.Repositories;

namespace Pinicules.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            var tmdbRepository = new TmdbRepository();
            var moviesContext = new MoviesContext();
            moviesContext.Database.Delete();
            var moviesRepository = new MoviesRepository(moviesContext);

            var movies = File.ReadAllLines("movies.txt", Encoding.UTF7);

            int total = movies.Count();
            int actual = 1;
            List<string> notFound = new List<string>();
            List<string> reintents = new List<string>();

            foreach ( var movieTitle in movies)
            {
                try
                {
                    AddMovie(tmdbRepository, moviesRepository, total, actual, notFound, movieTitle);
                    actual++;
                }
                catch
                {
                    reintents.Add(movieTitle);
                }
            }

            foreach (var movieTitle in reintents)
            {
                try
                {
                    AddMovie(tmdbRepository, moviesRepository, total, actual, notFound, movieTitle);
                }
                catch
                {
                }
            }

            File.WriteAllLines("NotFound.txt", notFound, Encoding.UTF7);
        }

        private static int AddMovie(TmdbRepository tmdbRepository, MoviesRepository moviesRepository, int total, int actual, List<string> notFound, string movieTitle)
        {
            if (!string.IsNullOrWhiteSpace(movieTitle))
            {
                Console.Write("Importing {0}/{1} -> {2} -->", actual, total, movieTitle);
                var candidateMovies = tmdbRepository.LookupMovies(movieTitle);

                if (candidateMovies != null && candidateMovies.Count > 0)
                {
                    moviesRepository.Add(candidateMovies.First().Id, candidateMovies.First().Title);
                    Console.WriteLine("OK");
                }
                else
                {
                    Console.WriteLine("NOT FOUND");
                    notFound.Add(movieTitle);
                }
            }
            return actual;
        }
    }
}
