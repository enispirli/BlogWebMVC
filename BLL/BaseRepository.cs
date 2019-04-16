using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseRepository<TEntitty>where  TEntitty:class
    {
        BlogContext db;
        public BaseRepository(BlogContext db)
        {
            this.db = db;
        }
        public List<TEntitty> GetAll()
        {
            return db.Set<TEntitty>().ToList();
        }
        public bool Add(TEntitty newData)
        {
            db.Set<TEntitty>().Add(newData);
            int row = db.SaveChanges();
            return row > 0;
        }
        public TEntitty GetById(int id)
        {
            return db.Set<TEntitty>().Find(id);
        }
        public void Delete(int i)
        {
            var deleteItem = GetById(i);
            db.Set<TEntitty>().Remove(deleteItem);
            db.SaveChanges();
        }
        public void Update(TEntitty newData)
        {
            Type t = typeof(TEntitty);
            PropertyInfo property = t.GetProperty("Id");
            int id = (int)property.GetValue(newData);

            var oldData = GetById(id);
            db.Entry(oldData).CurrentValues.SetValues(newData);
            db.SaveChanges();
            
        }

    }
}
