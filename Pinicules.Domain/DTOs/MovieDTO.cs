using System.Collections.Generic;

namespace Pinicules.Domain.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        private string comments;
        private float rating;

        public MovieDTO()
        {
        }

        public MovieDTO(int id, string comments, float rating)
        {
            this.Id = id;
            this.comments = comments;
            this.rating = rating;
        }

        public string Title { get; set; }

        public string Summary { get; set; }

        public List<string> Directors { get; set; }

        public List<string> Actors { get; set; }

        public string Image { get; set; }

        public List<string> Categories { get; set; }
    }
}
