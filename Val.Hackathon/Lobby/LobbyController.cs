using Microsoft.AspNetCore.Mvc;

namespace Val.Hackathon.Lobby
{
    public class LobbyController : Controller
    {
        [Route("lobby/{room}", Name = "Lobby")]
        public async Task<IActionResult> Index(string room)
        {
            var model = new LobbyModel()
            {
                Room = room,
                DisplayName = $"Room {room}"
            };

            return View(model);
        }

        [HttpPost]
        [Route("lobby/join")]
        public async Task<IActionResult> Join([FromForm] LobbyModel model)
        {
            return RedirectToAction("Index", "Room", new { room = model.Room });
        }
    }
}
