using Entities.ViewModels;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EscapeRoomApp.Controllers.api.Admin
{
    public class AdminController : ApiController
    {
        protected readonly IEmailService _emailService;
        public AdminController(IEmailService service)
        {
            _emailService = service;
        }

        [HttpPost]
        public IHttpActionResult EmailFromContact(ContactViewModel viewModel)
        {
            _emailService.ContactEmail(viewModel);

            return Ok();
        }
    }
}
