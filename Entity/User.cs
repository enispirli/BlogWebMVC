using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        [Required]
        [MaxLength(500)]
        [Index("Ix_UserName", Order = 1, IsUnique = true)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual List<Article> GetUserArticles { get; set; }
        public virtual List<Comment> GetUserComments { get; set; }

    }
}
