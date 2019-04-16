using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class TagRepository:BaseRepository<Tag>
    {
        BlogContext _db;
        public TagRepository(BlogContext db) : base(db)
        {
            _db = db;
        }

        public List<Tag> GetTags(string Tags)
        {
            var TagArray = Tags.Split(',');
             
            return _db.Tags.Where(x => TagArray.Contains(x.Id.ToString())).ToList(); 
        }
           
    }
}
