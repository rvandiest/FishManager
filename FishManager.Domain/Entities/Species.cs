using System.ComponentModel.DataAnnotations;

namespace FishManager.Domain.Entities
{
    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genus { get; set; }
    }
}