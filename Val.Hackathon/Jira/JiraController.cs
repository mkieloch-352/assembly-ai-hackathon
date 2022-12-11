using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Val.Hackathon.Jira
{
    [Route("api/[controller]")]
    [ApiController]
    public class JiraController : ControllerBase
    {
        [HttpGet]
        [Route("issue/metadata")]
        public async Task<IActionResult> GetIssueMetadataAsync()
        {
            var json = await JiraService.GetIssueMetadataAsync();
            return Ok(json);
        }

        [HttpPost]
        [Route("issue")]
        public async Task<IActionResult> CreateIssueAsync(IssueRequest request)
        {
            var json = await JiraService.CreateIssueAsync(request.Summary);
            return Ok(json);
        }
    }
}
