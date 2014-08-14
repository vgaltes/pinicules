using System.Data.Entity;
using Pinicules.Data.Entities;

namespace Pinicules.Data.Infrastructure
{
    public class MoviesContext : DbContext, IMoviesContext
    {
        public MoviesContext() : base("MoviesContext") { }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(a => a.Categories)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("Movie_Id");
                    x.MapRightKey("Category_Id");
                    x.ToTable("MovieCategories");
                });

            modelBuilder.Entity<Category>()
                .HasKey(c => c.Name);
        }
    }
}