using System.ComponentModel.DataAnnotations.Schema;

namespace _4fitter.Models
{
    public class Bookmark
    {
        public int ID { get; set; }

        public string UserID { get; set; }

        [NotMapped]
        public int ArticleID { get; set; }

        public virtual Article Article { get; set; }
    }
}