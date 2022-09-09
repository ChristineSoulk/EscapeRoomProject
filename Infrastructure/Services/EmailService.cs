using DatabaseLibrary;
using Entities;
using Entities.ViewModels;
using Infrastructure.Interfaces;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        protected UnitOfWork _unitOfWork;
        protected ApplicationContext db = new ApplicationContext();

        public EmailService()
        {
            _unitOfWork = new UnitOfWork(db);
        }

        public void SendEmailForBooking(BookingViewModel Booking)
        {
            string subject = "The Escape Room Project!";
            string htmlBody = this.CreateEmailBodyForBooking(Booking);
            MailMessage mailMessage = this.ComposeEmail(subject, htmlBody, Booking.Email);
            this.MailTransfer(mailMessage);

        }

        public void SendEmailForNewRoom(string email)
        {
            string subject = "The Escape Room Project - New Room Added!";
            string htmlBody = this.CreateEmailBodyForNewRoom();
            MailMessage mailMessage = this.ComposeEmail(subject, htmlBody, email);
            this.MailTransfer(mailMessage);
        }
        // Compose Email
        public MailMessage ComposeEmail(string subject, string body, string email)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("TheEscapeRoomProject@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            return mailMessage;
        }
        //Creating Client For Email
        public void MailTransfer(MailMessage mailMessage)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.UseDefaultCredentials = true;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("TheEscapeRoomProject@gmail.com", "siohtmvoasqjhenj");
                
                client.Send(mailMessage);
            }
        }

        //Creating Email Body for Booking details and new rooms
        public string CreateEmailBodyForBooking(BookingViewModel Booking)
        {
            var room = _unitOfWork.Rooms.GetById(Booking.RoomId);
                string body = $@"<html>
                                <head>    
                                    <title></title>
                                </head>
                                <body>
                                    <h3>Booking Details</h3>
                                    <p>Dear {Booking.FirstName} {Booking.LastName}</p>
                                    <p>You have made a Booking for room {room.Title} on {Booking.GameDate.ToShortDateString()} at {Booking.GameTime.ToShortTimeString()} pm.</p>
                                    <br />
                                    <p>Anikitoi,Peoplecert CB16</p>
                                </body>
                            </html>";

                return body;
        }

        public string CreateEmailBodyForNewRoom()
        {
                string body = $@"<html>
                                <head>    
                                    <title></title>
                                </head>
                                <body>
                                    <h3>New Room Avalaible</h3>
                                    <p>Test</p>
                                    <p>Anikitoi,Peoplecert CB16</p>
                                </body>
                            </html>";
                return body;
        }
        public List<string> GetEmailAddressesOfSubscribers()
{
                var emailList = _unitOfWork.Players.GetAll()
                                      .Where(x => x.IsSubscribed == true)
                                      .Select(x => x.Email)
                                      .Union(_unitOfWork.Bookings.GetAll()
                                                                    .Where(x => x.IsSubscribed == true)
                                                                    .Select(x => x.Email))
                                                                    .Distinct().ToList();

                return emailList;
        }
    }
}
