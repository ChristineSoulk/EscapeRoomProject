using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EscapeRoomApp.Controllers
{
    public class RoomApiController : BaseClassApiController
    {
        [HttpGet]
        public IEnumerable<Room> GetRooms()
        {
            return UnitOfWork.Rooms.GetAll().ToList();
        }
        [HttpGet]
        public Room GetRoom(int? id)
        {
            if(id is null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var room = UnitOfWork.Rooms.GetById(id);
            if(room is null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return room;
        }
        [HttpPost]
        public IHttpActionResult Post(Room room)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Rooms.Insert(room);
            }

            return Ok();
        }
        

    }
}
