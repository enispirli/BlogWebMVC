using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ArticleRepository:BaseRepository<Article>
    {
        BlogContext _db;
        public ArticleRepository(BlogContext db) : base(db)
        {
            _db = db;
        }

        public List<Article> OrderByDate()
        {
           return GetAll().OrderByDescending(x => x.ArticleDate).ToList();
        }
    }
}
