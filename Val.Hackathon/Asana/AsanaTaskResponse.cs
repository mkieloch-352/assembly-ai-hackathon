using System.Text.Json.Serialization;

namespace Val.Hackathon.Asana
{
    public class AsanaTaskResponse
    {
        [JsonPropertyName("gid")]
        public string Id { get; set; }

        [JsonPropertyName("resource_type")]
        public string ResourceType { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("modified_at")]
        public DateTime UpdatedDate { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("assignee_status")]
        public string Status { get; set; }

        [JsonPropertyName("permalink_url")]
        public string Url { get; set; }

        /*
         * {
    "data": {
        "gid": "1203527841920141",
        "projects": [],
        "memberships": [],
        "resource_type": "task",
        "created_at": "2022-12-11T00:46:37.804Z",
        "modified_at": "2022-12-11T00:46:37.952Z",
        "name": "testing 123",
        "notes": "2a3c6143-8260-4121-b1f6-81b63eb62815",
        "assignee": null,
        "completed": false,
        "assignee_status": "upcoming",
        "completed_at": null,
        "due_on": null,
        "due_at": null,
        "resource_subtype": "default_task",
        "start_on": null,
        "start_at": null,
        "tags": [],
        "workspace": {
            "gid": "1203520623012050",
            "resource_type": "workspace",
            "name": "My Workspace"
        },
        "num_hearts": 0,
        "num_likes": 0,
        "custom_fields": [],
        "parent": null,
        "hearted": false,
        "hearts": [],
        "liked": false,
        "likes": [],
        "permalink_url": "https://app.asana.com/0/1203520623012064/1203527841920141",
        "followers": [
            {
                "gid": "1203520623012040",
                "resource_type": "user",
                "name": "Michal Kieloch"
            }
        ]
    }
}
         */
    }
}
