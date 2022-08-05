using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Core.Repositories
{
    public interface IRoomRepository
    {
        void Insert(Room room);
        Room GetById(int? id);
        IEnumerable<Room> GetAllRooms();
        void Update(Room room);
        void Delete(int? id);
        void Save();
    }
}
