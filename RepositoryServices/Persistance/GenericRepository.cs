using DatabaseLibrary;
using RepositoryServices.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ApplicationContext db = new ApplicationContext();
        public DbSet<T> model;
        public GenericRepository(ApplicationContext context)
        {
            db = context;
            model = db.Set<T>();
        }
        public void Delete(object id)
        {
            var existing = model.Find(id);
            db.Entry(existing).State = EntityState.Deleted;
            Save();
        }

        public IEnumerable<T> GetAll()
        {
            return model.ToList();
        }

        public T GetById(int? id)
        {
            return model.Find(id);
        }


        public void Insert(T obj)
        {
            model.Add(obj);
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T obj)
        {
            model.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
            Save();
        }
    }
}
