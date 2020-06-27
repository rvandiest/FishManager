using System;

namespace FishManager.API.RequestModels
{
    public class CasualtyReport
    {
        public string Species { get; set; }
        public string Genus { get; set; }
        public string Cause { get; set; }
        public string Category { get; set; }
        public int Number { get; set; }
        public DateTime Timestamp { get; set; }
    }
}