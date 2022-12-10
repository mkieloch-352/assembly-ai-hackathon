using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Val.Hackathon.AsssemblyAI
{
    [Route("api/assembly")]
    [ApiController]
    public class AssemblyAIController : ControllerBase
    {
        [Route("token")]
        [HttpGet]
        public async Task<IActionResult> GetTokenAsync()
        {
            string url = "https://api.assemblyai.com/v2/realtime/token";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "b05c60838d154ba8976e0fd7a4c651cf");

            var body = new { expires_in = 3600 };
            var response = await client.PostAsJsonAsync(url, body);
            string json = await response.Content.ReadAsStringAsync();
            return Ok(json);
        }
    }
}
