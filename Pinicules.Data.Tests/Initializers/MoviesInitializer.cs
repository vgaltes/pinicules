using System.Data.Entity;
using Pinicules.Data.Entities;
using Pinicules.Data.Infrastructure;
using Pinicules.Domain.DTOs;

namespace Pinicules.Data.Tests.Initializers
{
    public class MoviesInitializer : DropCreateDatabaseAlways<MoviesContext>
    {
        protected override void Seed(MoviesContext context)
        {
            context.Movies.Add(new Movie() { Id = 100402, Title = "Captain America: The Winter Soldier" });
            context.Movies.Add(new Movie() { Id = 102382, Title = "The Amazing SpiderMan 2" });
            context.Movies.Add(new Movie() { Id = 157350, Title = "Divergente" });
            context.Movies.Add(new Movie() { Id = 193610, Title = "Mujeres al ataque" });
            context.Movies.Add(new Movie() { Id = 138103, Title = "Expendables 3" });
            context.Movies.Add(new Movie() { Id = 119450, Title = "Planeta simios" });
            context.Movies.Add(new Movie() { Id = 86834, Title = "Noe" });
            context.Movies.Add(new Movie() { Id = 127585, Title = "x-men" });
            context.Movies.Add(new Movie() { Id = 240832, Title = "Lucy" });
            context.Movies.Add(new Movie() { Id = 172385, Title = "RIO 2" });
            context.Movies.Add(new Movie() { Id = 62241, Title = "Long way down" });
            context.Movies.Add(new Movie() { Id = 210024, Title = "An adventure in space and dime" });
            context.Movies.Add(new Movie() { Id = 1771, Title = "Capitan America" });
            context.Movies.Add(new Movie() { Id = 152737, Title = "Agosto" });
            context.Movies.Add(new Movie() { Id = 157353, Title = "Transcendence" });
        }
    }
}