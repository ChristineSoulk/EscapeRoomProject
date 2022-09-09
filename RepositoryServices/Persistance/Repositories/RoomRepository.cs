using DatabaseLibrary;
using Entities;
using Entities.Models;
using RepositoryServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationContext context) : base(context)
        {
        }

        
    }
}
