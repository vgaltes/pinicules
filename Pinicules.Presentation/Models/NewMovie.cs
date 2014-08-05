namespace Pinicules.Presentation.Models
{
    public class NewMovie
    {
        public NewMovie(int movieId, string title)
        {
            this.MovieId = movieId;
            this.Title = title;
        }

        public int MovieId { get; set; }
        private string Title { get; set; }
    }
}