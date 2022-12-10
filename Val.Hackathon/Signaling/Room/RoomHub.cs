using Val.Hackathon.Signaling.RTC;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Val.Hackathon.Signaling.Room
{
    public class RoomHub : Hub
    {
        public async Task SendMessage(MessageModel model)
        {
            await Clients.OthersInGroup(model.Room).SendAsync("NewMessage", model);
        }

        public async Task SendOffer(SdpModel model)
        {
            await Clients.Client(model.UserId).SendAsync("Offer", model);
        }

        public async Task SendAnswer(SdpModel model)
        {
            await Clients.Client(model.UserId).SendAsync("Answer", model);
        }

        public async Task SendIceCandidate(IceModel model)
        {
            await Clients.Client(model.UserId).SendAsync("IceCandidate", model);
        }

        public async Task JoinRoom(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
        }

        public async Task UserJoining(RoomModel model)
        {
            await Clients.OthersInGroup(model.Room).SendAsync("UserJoining", model);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
