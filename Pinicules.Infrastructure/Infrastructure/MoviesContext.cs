using System.Data.Entity;
using Pinicules.Data.Entities;

namespace Pinicules.Data.Infrastructure
{
    public class MoviesContext : DbContext
    {
        public MoviesContext() : base("MoviesContext") { }

        public DbSet<Movie> Movies { get; set; }
    }
}