
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Val.Hackathon.Signaling.Room
{
    public class RoomController : Controller
    {
        private readonly IHubContext<RoomHub> _hub;

        public RoomController(IHubContext<RoomHub> hub) 
        {
            _hub = hub;
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
            //await _messageProcessor.Process(_hub, _sessionService, model);
            return Ok();
        }

        [HttpGet]
        [Route("room/{room}/messages/{userId}", Name = "RoomMessages")]
        public async Task<IActionResult> GetMessages(string room, string userId)
        {
            //List<MessageModel> messages = await _messageRepository.GetAllAsync(room, userId);
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
            //await _sessionService.LeaveAsync(model);
            return Ok();
        }
    }
}
