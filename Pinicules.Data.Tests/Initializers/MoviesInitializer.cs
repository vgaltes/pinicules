using System.Collections.Generic;
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
            context.Categories.Add(new Category { Name = "Drama" });
            context.Categories.Add(new Category { Name = "Comedy" });
            context.Categories.Add(new Category { Name = "Thriller" });
            context.Categories.Add(new Category { Name = "Cartoon" });
            context.Categories.Add(new Category { Name = "History" });
            context.Categories.Add(new Category { Name = "Action" });

            context.SaveChanges();

            var drama = context.Categories.Find("Drama");
            var comedy = context.Categories.Find("Comedy");
            var thriller = context.Categories.Find("Thriller");
            var cartoon = context.Categories.Find("Cartoon");
            var history = context.Categories.Find("History");
            var action = context.Categories.Find("Action");

            context.Movies.Add(new Movie() { Id = 100402, Title = "Captain America: The Winter Soldier", Categories = new List<Category>() { action } });
            context.Movies.Add(new Movie() { Id = 102382, Title = "The Amazing SpiderMan 2", Categories = new List<Category>() { action } });
            context.Movies.Add(new Movie() { Id = 157350, Title = "Divergente", Categories = new List<Category>() { comedy } });
            context.Movies.Add(new Movie() { Id = 193610, Title = "Mujeres al ataque", Categories = new List<Category>() { comedy } });
            context.Movies.Add(new Movie() { Id = 138103, Title = "Expendables 3", Categories = new List<Category>() { action } });
            context.Movies.Add(new Movie() { Id = 119450, Title = "Planeta simios", Categories = new List<Category>() { action } });
            context.Movies.Add(new Movie() { Id = 86834, Title = "Noe", Categories = new List<Category>() { history } });
            context.Movies.Add(new Movie() { Id = 127585, Title = "x-men", Categories = new List<Category>() { action } });
            context.Movies.Add(new Movie() { Id = 240832, Title = "Lucy", Categories = new List<Category>() { comedy } });
            context.Movies.Add(new Movie() { Id = 172385, Title = "RIO 2", Categories = new List<Category>() { cartoon } });
            context.Movies.Add(new Movie() { Id = 62241, Title = "Long way down", Categories = new List<Category>() { drama } });
            context.Movies.Add(new Movie() { Id = 210024, Title = "An adventure in space and dime", Categories = new List<Category>() { thriller } });
            context.Movies.Add(new Movie() { Id = 1771, Title = "Capitan America", Categories = new List<Category>() { action } });
            context.Movies.Add(new Movie() { Id = 152737, Title = "Agosto", Categories = new List<Category>() { thriller } });
            context.Movies.Add(new Movie() { Id = 157353, Title = "Transcendence", Categories = new List<Category>() { comedy } });
        }
    }
}