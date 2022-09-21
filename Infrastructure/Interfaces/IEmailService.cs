using Entities;
using Entities.Models;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IEmailService
    {
        void SendEmailForBooking(BookingViewModel Booking);
        void SendEmailForNewRoom(string email, Room room);
        List<string> GetEmailAddressesOfSubscribers();
        void ContactEmail(ContactViewModel contactmodel);
    }
}
