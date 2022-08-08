using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Core
{
    public interface IGenericRepository<T> where T : class
    {
        void Insert(T obj);
        T GetById(int? id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
