﻿using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Core.Repositories
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        List<Reservation> GetReservations();
       
        
    }
}
