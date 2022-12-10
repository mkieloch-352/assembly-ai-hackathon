namespace Val.Hackathon.Signaling.Room
{
    public class LeaveRoomModel
    {
        public string UserId { get; set; }
        public string Room { get; set; }
        public string DisplayName { get; set; }
        public string ConnectionId { get; set; }
    }
}
