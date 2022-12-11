using System.Text.Json.Serialization;

namespace Val.Hackathon.Jira
{
    public class JiraCreateIssueResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("self")]
        public string Url { get; set; }

        /*
         * {"id":"10000","key":"AH-1","self":"https://kieloch.atlassian.net/rest/api/3/issue/10000"}
         */
    }
}
