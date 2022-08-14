using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EscapeRoomApp.Controllers
{
    public class ReservationApiController : BaseClassApiController
    {
        [HttpGet]
        public IEnumerable<Reservation> GetAllReservations()
        {
            return UnitOfWork.Reservations.GetDatesOfReservations().ToList();
        }
        [HttpPost]
        public IHttpActionResult MakeReservation(int playerId, int roomId, int numberOfPlayers,DateTime gameStarts,DateTime gameEnds)
        {
            var player = UnitOfWork.Players.GetById(playerId);
            var room = UnitOfWork.Rooms.GetById(roomId);

            Reservation reservation = new Reservation();
            reservation.Room = room;
            reservation.Player = player;
            reservation.NumberOfPlayers = numberOfPlayers;
            reservation.GameStarts = gameStarts;
            reservation.GameEnds = gameEnds;

            UnitOfWork.Reservations.Insert(reservation);


            return Ok();
        }
    }
}
