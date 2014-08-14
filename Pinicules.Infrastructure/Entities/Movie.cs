using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinicules.Data.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Category> Categories {get;set;}
    }

    public class Category
    {
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Category))
                return false;
            else
            {
                var otherCategory = obj as Category;
                return this.Name == otherCategory.Name;
            }
        }
    }
}
