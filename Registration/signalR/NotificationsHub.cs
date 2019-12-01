using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.signalR
{
    public class NotificationsHub : Hub<INotificationsHub>, INotificationsHub
    {
        public async Task SendNotification(string message)
        {
            await Clients.Caller.SendNotification(message);
        }
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Who is connected: " + Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
