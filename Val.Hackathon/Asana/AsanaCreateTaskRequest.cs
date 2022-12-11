using System.Text.Json.Serialization;

namespace Val.Hackathon.Asana
{
    public class AsanaCreateTaskRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("workspace")]
        public string Workspace { get; set; } = "1203520623012050";

        /*
         * {
  "data": {
    "approval_status": "pending",
    "assignee": "12345",
    "assignee_section": "12345",
    "assignee_status": "upcoming",
    "completed": false,
    "completed_by": {
      "name": "Greg Sanchez"
    },
    "custom_fields": {
      "4578152156": "Not Started",
      "5678904321": "On Hold"
    },
    "due_at": "2019-09-15T02:06:58.147Z",
    "due_on": "2019-09-15",
    "external": {
      "data": "A blob of information",
      "gid": "my_gid"
    },
    "followers": [
      "12345"
    ],
    "html_notes": "<body>Mittens <em>really</em> likes the stuff from Humboldt.</body>",
    "liked": true,
    "name": "Buy catnip",
    "notes": "Mittens really likes the stuff from Humboldt.",
    "parent": "12345",
    "projects": [
      "12345"
    ],
    "resource_subtype": "default_task",
    "start_at": "2019-09-14T02:06:58.147Z",
    "start_on": "2019-09-14",
    "tags": [
      "12345"
    ],
    "workspace": "12345"
  }
}
         */
    }
}
