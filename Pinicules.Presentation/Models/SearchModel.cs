using System.Collections.Generic;

namespace Pinicules.Presentation.Models
{
    public class SearchModel
    {
        public SearchModel()
        {
            Categories = new List<string>();
        }

        public List<string> Categories { get; set; }
    }
}