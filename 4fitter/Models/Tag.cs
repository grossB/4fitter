using System.Collections.Generic;

namespace _4fitter.Models
{
    public class Tag
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public Tag()
        {
            this.Articles = new HashSet<Article>();
        }
    }
}