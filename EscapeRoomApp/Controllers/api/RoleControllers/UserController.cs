using Entities.Exceptions;
using EscapeRoomApp.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace EscapeRoomApp.Controllers.api.RoleControllers
{
    public class UserController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public IHttpActionResult Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.Users.Add(applicationUser);
            _context.SaveChanges();

            return Ok();
        }
    }
}
