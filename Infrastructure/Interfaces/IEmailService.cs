using Entities;
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
        void SendEmailForNewRoom(string email);
        List<string> GetEmailAddressesOfSubscribers();
    }
}
