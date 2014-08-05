using Pinicules.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pinicules.Presentation.Models
{
    public class MoviesSearchResult
    {
        public List<MovieSearchItem> Items
        {
            get;
            set;
        }

        public bool LoadMore { get; set; }

        public int NextPage { get; set; }
    }
}