using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UnitOfWork
    {
        public BlogContext db;
        public UserRepository userRepository;
        public ArticleRepository articleRepository;
        public BaseRepository<Category> categoryRepository;
        public TagRepository tagRepository;
        public BaseRepository<Comment> commentRepository;
        public UnitOfWork()
        {
            db = new BlogContext();
            userRepository = new UserRepository(db);
            articleRepository = new ArticleRepository(db);
            categoryRepository = new BaseRepository<Category>(db);
            tagRepository = new  TagRepository(db);
            commentRepository = new BaseRepository<Comment>(db);
        }

    }
}
