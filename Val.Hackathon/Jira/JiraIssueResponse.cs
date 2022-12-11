using System.Text.Json.Serialization;

namespace Val.Hackathon.Jira
{
    public class JiraIssueResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("fields")]
        public Dictionary<string, object> Fields { get; set; }

        public string Url { get; set; }

        public string Summary
        {
            get
            {
                return Fields["summary"]?.ToString();
            }
        }

        public string Description
        {
            get
            {
                return Fields["description"]?.ToString();
            }
        }

        /*
         * {
  "expand": "",
  "id": "10002",
  "self": "https://your-domain.atlassian.net/rest/api/3/issue/10002",
  "key": "ED-1",


    "description": {
      "type": "doc",
      "version": 1,
      "content": [
        {
          "type": "paragraph",
          "content": [
            {
              "type": "text",
              "text": "Main order flow broken"
            }
          ]
        }
      ]
    },
    "project": {
      "self": "https://your-domain.atlassian.net/rest/api/3/project/EX",
      "id": "10000",
      "key": "EX",
      "name": "Example",
      "avatarUrls": {
        "48x48": "https://your-domain.atlassian.net/secure/projectavatar?size=large&pid=10000",
        "24x24": "https://your-domain.atlassian.net/secure/projectavatar?size=small&pid=10000",
        "16x16": "https://your-domain.atlassian.net/secure/projectavatar?size=xsmall&pid=10000",
        "32x32": "https://your-domain.atlassian.net/secure/projectavatar?size=medium&pid=10000"
      },
      "projectCategory": {
        "self": "https://your-domain.atlassian.net/rest/api/3/projectCategory/10000",
        "id": "10000",
        "name": "FIRST",
        "description": "First Project Category"
      },
      "simplified": false,
      "style": "classic",
      "insight": {
        "totalIssueCount": 100,
        "lastIssueUpdateTime": "2022-12-08T07:09:19.702+0000"
      }
    },



  }
}
         */
    }
}
