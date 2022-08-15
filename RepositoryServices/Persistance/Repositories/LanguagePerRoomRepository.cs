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
    public class LanguagePerRoomRepository : GenericRepository<LanguagePerRoom>, ILanguagePerRoomRepository
    {
        public LanguagePerRoomRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
