using _4fitter.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4fitter.Models
{
    public class Article
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Adres URL ilustracji")]
        public string IllustrationURL { get; set; }

        [Required]
        [Display(Name = "Łatwy identyfikator")]
        public string FriendlyID { get; set; }

        [Required]
        [Display(Name = "Typ artykułu")]
        public ArticleTypeEnum ArticleType { get; set; }

        [Required]
        public string ContentTextFormatted { get; set; }

        [Display(Name = "Autor")]
        public string Author { get; set; }

        [Required]
        [NotMapped]
        public string RawTags { get; set; }

        [Display(Name = "Tagi")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}