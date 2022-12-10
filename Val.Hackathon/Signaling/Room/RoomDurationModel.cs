using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Val.Hackathon.Signaling.Room
{
    public class RoomDurationModel
    {
        public string RoomId { get; set; }
        public int ActiveDuration { get; set; }
        public string Source { get; set; }
    }
}
