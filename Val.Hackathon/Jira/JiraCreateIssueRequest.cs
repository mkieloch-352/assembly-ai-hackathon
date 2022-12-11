using System.Text.Json.Serialization;

namespace Val.Hackathon.Jira
{
    public class JiraCreateIssueRequest
    {
        [JsonIgnore]
        public string Summary { get; set; }

        [JsonIgnore]
        public string IssueType { get; set; } = "10002";

        [JsonPropertyName("fields")]
        public Dictionary<string, object> Fields { get; set; }

        public JiraCreateIssueRequest(string summary)
        {
            Fields = new Dictionary<string, object>();
            Fields.Add("summary", summary);
            Fields.Add("issuetype", new { id = IssueType });
            Fields.Add("project", new { id = "10000" });
        }
        /*
         * {
  "update": {},
  "fields": {
    "summary": "Main order flow broken",
    "parent": {
      "key": "PROJ-123"
    },
    "issuetype": {
      "id": "10000"
    },
    "components": [
      {
        "id": "10000"
      }
    ],
    "customfield_20000": "06/Jul/19 3:25 PM",
    "customfield_40000": {
      "type": "doc",
      "version": 1,
      "content": [
        {
          "type": "paragraph",
          "content": [
            {
              "text": "Occurs on all orders",
              "type": "text"
            }
          ]
        }
      ]
    },
    "customfield_70000": [
      "jira-administrators",
      "jira-software-users"
    ],
    "project": {
      "id": "10000"
    },
    "description": {
      "type": "doc",
      "version": 1,
      "content": [
        {
          "type": "paragraph",
          "content": [
            {
              "text": "Order entry fails when selecting supplier.",
              "type": "text"
            }
          ]
        }
      ]
    },
    "reporter": {
      "id": "5b10a2844c20165700ede21g"
    },
    "fixVersions": [
      {
        "id": "10001"
      }
    ],
    "priority": {
      "id": "20000"
    },
    "labels": [
      "bugfix",
      "blitz_test"
    ],
    "timetracking": {
      "remainingEstimate": "5",
      "originalEstimate": "10"
    },

    "security": {
      "id": "10000"
    },

    "versions": [
      {
        "id": "10000"
      }
    ],
    "duedate": "2019-05-11",
    "assignee": {
      "id": "5b109f2e9729b51b54dc274d"
    }
  }
}
         */
    }
}
