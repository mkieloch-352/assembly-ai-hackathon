using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Val.Hackathon.Asana
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsanaController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync(AsanaCreateTaskRequest request)
        {
            var response = await AsanaService.CreateTaskAsync(request.Name, request.Notes);
            return Ok(response);
        }
    }
}
