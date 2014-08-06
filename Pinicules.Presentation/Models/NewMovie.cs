namespace Pinicules.Presentation.Models
{
    public class NewMovie
    {
        public NewMovie(int movieId, string title)
        {
            this.MovieId = movieId;
            this.Title = title;
        }

        public NewMovie() { }

        public int MovieId { get; set; }
        public string Title { get; set; }
    }
}