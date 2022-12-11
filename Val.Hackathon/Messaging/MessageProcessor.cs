using Val.Hackathon.Signaling;
using Val.Hackathon.Signaling.Room;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Val.Hackathon.Messaging
{
    public class MessageProcessor : IMessageProcessor
    {
        public async Task Process(IHubContext<RoomHub> hub, MessageModel model)
        {
            if (model.DestinationUserId == MessageModel.All)
            {
                await hub.Clients.GroupExcept(model.Room, model.FromUserId).SendAsync("NewMessage", model);
            }
            else
            {
                await hub.Clients.Client(model.DestinationUserId).SendAsync("NewMessage", model);
            }
        }
    }
}
