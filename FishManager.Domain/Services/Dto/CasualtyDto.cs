using System;

namespace FishManager.Domain.Services.Dto
{
    public class CasualtyDto
    {
        public SpeciesDto Species { get; set; }
        public TankDto Tank { get; set; }
        public int Count { get; set; }
        public CasualtyCauseDto CasualtyCause { get; set; }
        public DateTime Timestamp { get; set; }
    }
}