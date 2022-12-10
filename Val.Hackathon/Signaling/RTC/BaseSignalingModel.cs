using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Val.Hackathon.Signaling.RTC
{
    public class BaseSignalingModel
    {
        public string UserId { get; set; }
        public string SourceUserId { get; set; }
        public string DisplayName { get; set; }
        public string Room { get; set; }

        public string MediaType { get; set; }
    }
}
