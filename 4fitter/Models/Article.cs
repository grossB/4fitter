using _4fitter.Enums;
using _4fitter.Utilities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string FriendlyID { get; set; }

        [Required]
        public ArticleTypeEnum ArticleType { get; set; }

        [Required]
        public string ContentTextFormatted { get; set; }

        public string Author { get; set; }

        [Required]
        public string RawTags { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}