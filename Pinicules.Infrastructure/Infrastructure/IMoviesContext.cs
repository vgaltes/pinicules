using System;
using System.Data.Entity;
using Pinicules.Data.Entities;

namespace Pinicules.Data.Infrastructure
{
    public interface IMoviesContext
    {
        DbSet<Movie> Movies { get; set; }

        void Save();
    }
}
