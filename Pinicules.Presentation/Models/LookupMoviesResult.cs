using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pinicules.Presentation.Models
{
    public class LookupMoviesResult
    {
        public List<LookupMovieItem> Items { get; set; }
    }

    public class LookupMovieItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }
    }
}