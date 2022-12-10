using System;

namespace Val.Hackathon.Signaling
{
    public class MessageModel
    {
        public const string All = "All";

        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string From { get; set; }
        public string FromUserId { get; set; }
        public string DestinationUserId { get; set; } = All;
        public string Room { get; set; }
        public long Timestamp { get; set; }
    }
}
