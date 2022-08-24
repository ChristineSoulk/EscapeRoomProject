using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EscapeRoomApp.Controllers.api
{
    public class RoomApiController : BaseClassApiController
    {
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
            if (roomId <= 0)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            UnitOfWork.Rooms.Delete(roomId);


            return Ok();
        }


    }
}
