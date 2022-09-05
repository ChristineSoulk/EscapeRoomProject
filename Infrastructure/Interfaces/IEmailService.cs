using Entities;
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
        void SendEmailForReservation(ReservationViewModel reservation);
        MailMessage ComposeEmail(string subject, string body, string email);
        void MailTransfer(MailMessage mailMessage);
        string CreateEmailBodyForReservation(ReservationViewModel reservation);
        void SendEmailForNewRoom(string email);
        string CreateEmailBodyForNewRoom();
        List<string> GetEmailAddressesOfSubscribers();
    }
}
