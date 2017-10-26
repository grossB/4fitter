using _4fitter.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _4fitter.Models
{
    public class Article
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string IllustrationURL { get; set; }

        [Required]
        //Add unique attribute
        public string FriendlyID { get; set; }

        [Required]
        public ArticleTypeEnum ArticleType { get; set; }

        [Required]
        public string ContentTextFormatted { get; set; }

        public string Author { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}