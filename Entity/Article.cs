using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Category")]
        public int CatergoryID { get; set; }
        [Required]
        [MaxLength(400)]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string ArticleContent { get; set; }
        public DateTime ArticleDate { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual List<Tag> GetArticleTags { get; set; }
        public virtual List<Comment> GetArticleComments { get; set; }


        public Article()
        {
            ArticleDate = DateTime.Now;
        }
    }
}
