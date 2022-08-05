using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Core.Repositories
{
    public interface IPlayerRepository
    {
        void Insert(Player player);
        Player GetById(int? id);
        void Update(Player player);
        void Save();
    }
}
