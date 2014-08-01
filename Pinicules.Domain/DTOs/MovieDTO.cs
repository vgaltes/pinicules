namespace Pinicules.Domain.DTOs
{
    public class MovieDTO
    {
        private int id;
        private string comments;
        private float rating;

        public MovieDTO(int id, string comments, float rating)
        {
            this.id = id;
            this.comments = comments;
            this.rating = rating;
        }
    }
}
