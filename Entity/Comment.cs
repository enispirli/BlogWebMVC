using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Comment
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Article")]
        public int ArticleID { get; set; }
        [MaxLength(50)]
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }

        public virtual User User { get; set; }
        public virtual Article Article { get; set; }
        public Comment()
        {
            CommentDate = DateTime.Now;
        }
    }
}
