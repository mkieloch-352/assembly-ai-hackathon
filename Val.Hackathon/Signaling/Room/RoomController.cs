
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Val.Hackathon.Messaging;

namespace Val.Hackathon.Signaling.Room
{
    public class RoomController : Controller
    {
        private readonly IHubContext<RoomHub> _hub;
        private readonly IMessageProcessor _messageProcessor;

        public RoomController(IHubContext<RoomHub> hub, IMessageProcessor messageProcessor) 
        {
            _hub = hub;
            _messageProcessor = messageProcessor;
        }

        [Route("room/{room}", Name = "Room")]
        public async Task<IActionResult> Index(string room)
        {
            var model = new RoomModel() { DisplayName = $"Room {room}", Room = room };
            return View(model);
        }

        [HttpPost]
        [Route("room/{room}/chat", Name = "RoomChat")]
        public async Task<IActionResult> Chat([FromBody] MessageModel model)
        {
            await _messageProcessor.Process(_hub, model);
            return Ok();
        }

        [HttpGet]
        [Route("room/{room}/messages/{userId}", Name = "RoomMessages")]
        public async Task<IActionResult> GetMessages(string room, string userId)
        {
            return Ok();
        }
        
        [HttpPost]
        [Route("room/duration", Name = "UpdateMeetingDuration")]
        public async Task<IActionResult> UpdateMeetingDuration([FromBody] RoomDurationModel model)
        {
            return Ok();
        }

        [HttpPost]
        [Route("room/{room}/leave", Name = "LeaveRoom")]
        public async Task<IActionResult> LeaveRoomAsync([FromBody] LeaveRoomModel model)
        {
            return Ok();
        }
    }
}
