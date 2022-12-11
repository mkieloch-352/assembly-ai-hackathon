using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Text;
using Val.Hackathon.Asana;
using Val.Hackathon.Jira;

namespace Val.Hackathon.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static string Transcript = "";

        [HttpPost]
        [Route("{platform}")]
        public async Task<IActionResult> CreateTaskAsync(string platform, [FromBody] TaskRequest request)
        {
            TaskResponse task = new TaskResponse();

            if (platform.ToLower() == "asana")
            {
                var response = await AsanaService.CreateTaskAsync(request.Title, "Automated task created from VAL");
                task.Id = response.Data.Id;
                task.Key = $"Asana-{task.Id}";
                task.Status = response.Data.Status;
                task.Url = response.Data.Url;
                task.Platform = "Asana";
                task.Message = $"Task created successfully in Asana";
            }
            else if (platform.ToLower() == "jira")
            {
                var response = await JiraService.CreateIssueAsync(request.Title);
                task.Id = response.Id;
                task.Key = response.Key;
                task.Url = response.Url;
                task.Platform = "Jira";
                task.Message = $"Task {task.Key} created successfully in Jira";
            }

            return Ok(task);
        }

        [HttpPost]
        [Route("email")]
        public async Task<IActionResult> SendEmailAsync([FromBody] TaskRequest request)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("kielochhackathon@gmail.com", "zrsdwxwyvrajdcfh"),
                EnableSsl = true
            };

            client.Send("kielochhackathon@gmail.com", "kielochhackathon@gmail.com", "AI Message From VAL", request.Title);
            var taskResponse = new TaskResponse
            {
                Message = $"Email successfully sent to {request.Name} - kielochhackathon@gmail.com with message: {request.Title}"
            };

            return Ok(taskResponse);
        }

        [HttpPost]
        [Route("export")]
        public async Task<IActionResult> ExportTranscriptAsync([FromBody] TranscriptRequest request)
        {
            Transcript = request.Data;
            return Ok();
        }

        [HttpGet]
        [Route("export")]
        public async Task<IActionResult> DownloadExportTranscriptAsync()
        {
            return File(Encoding.UTF8.GetBytes(Transcript), System.Net.Mime.MediaTypeNames.Application.Octet, "transcript.json");
        }
    }
}
