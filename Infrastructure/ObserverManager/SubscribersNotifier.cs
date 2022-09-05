using DatabaseLibrary;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ObserverManager
{
    public class SubscribersNotifier : ISubscribersNotifier
    {
        private IEmailService _emailService;
        protected ApplicationContext db = new ApplicationContext();

        protected UnitOfWork unitOfWork;
        public SubscribersNotifier()
        {
            unitOfWork = new UnitOfWork(db);
            _emailService = new EmailService();
        }
        public void NotifySubscribersForNewRoom()
        {
            var emailList = _emailService.GetEmailAddressesOfSubscribers();

            emailList.ForEach(x => _emailService.SendEmailForNewRoom(x));

        }


    }
}    
