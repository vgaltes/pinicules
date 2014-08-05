using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pinicules.Presentation.Models
{
    public class MovieItem
    {
        public string Title { get; set; }

        public List<string> Actors { get; set; }

        public List<string> Directors { get; set; }
    }
}