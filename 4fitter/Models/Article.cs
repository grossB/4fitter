using _4fitter.Enums;
using System.Collections.Generic;

namespace _4fitter.Models
{
    public class Article
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string IllustrationURL { get; set; }

        public string FriendlyID { get; set; }

        public ArticleTypeEnum ArticleType { get; set; }

        public string ContentTextFormatted { get; set; }

        public string Author { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}