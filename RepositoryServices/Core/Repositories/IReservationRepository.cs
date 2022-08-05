using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Core.Repositories
{
    public interface IReservationRepository
    {
        void Insert(Reservation reservation);
        Reservation GetById(int? id);
        void Update(Reservation reservation);
        void Delete(int? id);
        void Save();
    }
}
