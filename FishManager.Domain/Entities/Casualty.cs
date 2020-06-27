using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FishManager.Domain.Entities
{
    public class Casualty
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public Species Species { get; set; }
        public int Count { get; set; }
        public int CasualtyCauseId { get; set; }
        public CasualtyCause CasualtyCause { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
