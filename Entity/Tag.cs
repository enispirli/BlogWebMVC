using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string TagName { get; set; }

        public virtual List<Article> GetTagArticles { get; set; }
    }
}
