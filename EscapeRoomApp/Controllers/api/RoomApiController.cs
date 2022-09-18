using DatabaseLibrary;
using Entities;
using Entities.Models;
using Infrastructure.ObserverManager;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EscapeRoomApp.Controllers.api
{
    public class RoomApiController : BaseApiController
    {

        
        protected readonly ISubscribersNotifier _notifier;
        
        public RoomApiController(ISubscribersNotifier notifier)
        {
            _notifier = notifier;
        }

        [HttpGet]
        public IEnumerable<Room> GetRooms()
        {
            return UnitOfWork.Rooms.GetAll().ToList();
        }

        [HttpGet]
        public Room GetRoom(int? roomId)
        {
            if (roomId is null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var room = UnitOfWork.Rooms.GetById(roomId);
            if (room is null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return room;
        }

        [HttpPost]
        public IHttpActionResult CreateRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Rooms.Insert(room);
                _notifier.NotifySubscribersForNewRoom();
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateRoom(Room room)
        {

            if (ModelState.IsValid)
            {
                UnitOfWork.Rooms.Update(room);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteRoom(int? roomId)
        {
            if (roomId <= 0 || roomId is null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            UnitOfWork.Rooms.Delete(roomId);


            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
