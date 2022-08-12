using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EscapeRoomApp
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            name = Context.ConnectionId;
            // Call the broadcastMessage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}