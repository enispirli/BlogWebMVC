using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserRepository:BaseRepository<User>
    {
        BlogContext _db;
        public UserRepository(BlogContext db):base(db)
        {
            _db = db;
        }
        public User Login(string Email,string Password)
        {
          return _db.Users.FirstOrDefault(x => x.Email == Email && x.Password == Password);
        }
    }
}
