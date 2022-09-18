using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EscapeRoomApp.Controllers.api
{
    public class PlayerApiController : BaseApiController
    {
        [HttpGet]
        public IEnumerable<Player> GetPlayers()
        {
            return UnitOfWork.Players.GetAll();
        }
        [HttpGet]
        public Player GetPlayer(int? id)
        {
            return UnitOfWork.Players.GetById(id);
        }
        [HttpPost]
        public IHttpActionResult Post(Player player)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a Valid Data");

            UnitOfWork.Players.Insert(player);

            return Ok(player);
        }
        [HttpPut]
        public IHttpActionResult UpdateDataOfPlayer(Player newPlayerData)
        {
            var player = UnitOfWork.Players.GetById(newPlayerData.Id);
            player.FirstName = newPlayerData.FirstName;
            player.LastName = newPlayerData.LastName;
            player.Email = newPlayerData.Email;
            player.PhoneNumber = newPlayerData.PhoneNumber;
            UnitOfWork.Players.Update(player);

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            UnitOfWork.Players.Delete(id);

            return Ok();
        }
    }
}
