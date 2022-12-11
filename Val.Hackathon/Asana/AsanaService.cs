using System.Net.Http.Headers;

namespace Val.Hackathon.Asana
{
    public class AsanaService
    {
        private const string Token = "1/1203520623012040:4fd8bb18cb58854bc69bcd2618abe4e1";

        public static async Task<object> CreateTaskAsync(string name, string notes)
        {
            string url = "https://app.asana.com/api/1.0/tasks";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            var request = new AsanaRequest<AsanaCreateTaskRequest>(new AsanaCreateTaskRequest
            {
                Name = name,
                Notes = notes
            });

            var response = await client.PostAsJsonAsync(url, request);
            string json = await response.Content.ReadAsStringAsync();
            return json;
        }
    }
}
