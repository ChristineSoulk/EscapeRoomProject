using DatabaseLibrary;
using Entities;
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

        public void SendEmailForReservation(ReservationViewModel reservation)
        {
            string subject = "The Escape Room Project!";
            string htmlBody = this.CreateEmailBodyForReservation(reservation);
            MailMessage mailMessage = this.ComposeEmail(subject, htmlBody, reservation.Email);
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

        //Creating Email Body for Reservation details and new rooms
        public string CreateEmailBodyForReservation(ReservationViewModel reservation)
        {
            var room = _unitOfWork.Rooms.GetById(reservation.RoomId);
                string body = $@"<html>
                                <head>    
                                    <title></title>
                                </head>
                                <body>
                                    <h3>Reservation Details</h3>
                                    <p>Dear {reservation.FirstName} {reservation.LastName}</p>
                                    <p>You have made a reservation for room {room.Title} on {reservation.GameDate.ToShortDateString()} at {reservation.GameTime.ToShortTimeString()} pm.</p>
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
                                      .Union(_unitOfWork.Reservations.GetAll()
                                                                    .Where(x => x.IsSubscribed == true)
                                                                    .Select(x => x.Email))
                                                                    .Distinct().ToList();

                return emailList;
        }
    }
}
