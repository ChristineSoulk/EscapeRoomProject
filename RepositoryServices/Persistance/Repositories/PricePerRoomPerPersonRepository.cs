using DatabaseLibrary;
using Entities;
using RepositoryServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance.Repositories
{
    public class PricePerRoomPerPersonRepository : GenericRepository<PricePerRoomPerPerson>, IPricePerRoomPerPersonRepository
    {
        public PricePerRoomPerPersonRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
