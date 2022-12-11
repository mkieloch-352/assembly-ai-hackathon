using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Val.Hackathon.Jira
{
    public class JiraService
    {
        private const string Token = "l0IPe4pgvwa1dIZeA09ACBAE";
        private const string User = "mkieloch352@gmail.com";
        private const string BaseUrl = "https://kieloch.atlassian.net";

        private const string IssueEndpoint = "/rest/api/3/issue";
        private const string IssueMetaDataEndpoint = "/rest/api/3/issue/createmeta";

        public static async Task<string> GetIssueMetadataAsync()
        {
            var client = new HttpClient();
            string url = $"{BaseUrl}{IssueMetaDataEndpoint}";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", GetBasicAuth());

            var response = await client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            return json;

        }

        public static async Task<JiraCreateIssueResponse> CreateIssueAsync(string summary)
        {
            var client = new HttpClient();
            string url = $"{BaseUrl}{IssueEndpoint}";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", GetBasicAuth());

            var request = new JiraCreateIssueRequest(summary);
            var response = await client.PostAsJsonAsync(url, request);
            string json = await response.Content.ReadAsStringAsync();
            var issue = JsonSerializer.Deserialize<JiraCreateIssueResponse>(json);
            issue.Url = $"{BaseUrl}/browse/{issue.Key}";
            return issue;
        }

        public static async Task<JiraIssueResponse> GetAsync(string key)
        {
            key = $"AH-{key}";
            var client = new HttpClient();
            string url = $"{BaseUrl}{IssueEndpoint}/{key}";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", GetBasicAuth());

            var response = await client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            var issue = JsonSerializer.Deserialize<JiraIssueResponse>(json);
            issue.Url = $"{BaseUrl}/browse/{issue.Key}";
            return issue;
        }

        private static string GetBasicAuth()
        {
            string auth = $"{User}:{Token}";
            var bytes = Encoding.UTF8.GetBytes(auth);
            string base64 = Convert.ToBase64String(bytes);
            return base64;
        }
    }
}
