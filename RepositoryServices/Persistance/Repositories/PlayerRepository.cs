using DatabaseLibrary;
using Entities;
using Entities.Models;
using RepositoryServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance.Repositories
{
    public class PlayerRepository : GenericRepository<Player>,IPlayerRepository
    {
        public PlayerRepository(ApplicationContext context) : base(context) 
        {

        }
    }
}
