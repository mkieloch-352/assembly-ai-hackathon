using Val.Hackathon.Signaling;
using Val.Hackathon.Signaling.Room;
using Microsoft.AspNetCore.SignalR;

namespace Val.Hackathon.Messaging
{
    public interface IMessageProcessor
    {
        Task Process(IHubContext<RoomHub> hub, MessageModel model);
    }
}
