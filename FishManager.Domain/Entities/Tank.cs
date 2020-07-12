using System.Collections.Generic;

namespace FishManager.Domain.Entities
{
    public class Tank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Casualty> Casualties { get; set; }
    }
}