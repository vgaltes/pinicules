using Pinicules.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pinicules.Presentation.Models
{
    public class MovieItem
    {
        public MovieItem(MovieDTO movieDTO, string previousSearch)
        {
            this.Id = movieDTO.Id;
            this.Title = movieDTO.Title;
            this.Actors = movieDTO.Actors;
            this.Directors = movieDTO.Directors;
            this.Image = movieDTO.Image;
            this.Summary = movieDTO.Summary;
            this.PreviousSearch = previousSearch;
            this.Categories = movieDTO.Categories;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public List<string> Actors { get; set; }

        public List<string> Directors { get; set; }

        public string PreviousSearch { get; set; }

        public string Image { get; set; }

        public string Summary { get; set; }

        public List<string> Categories { get; set; }
    }
}