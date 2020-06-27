using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FishManager.Domain.Entities
{
    public class CasualtyCause
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<Casualty> Casualties { get; set; }
    }
}