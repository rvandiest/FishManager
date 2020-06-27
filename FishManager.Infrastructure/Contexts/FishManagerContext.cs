using FishManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FishManager.Infrastructure.Contexts
{
    public class FishManagerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=fishmanager;Uid=root;Pwd=root;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Casualty>()
                        .HasOne(cc=>cc.CasualtyCause)
                        .WithMany(cs=>cs.Casualties);
        }

        //entities
        public DbSet<Species> Species { get; set; }
        public DbSet<Casualty> Casualties { get; set; }
        public DbSet<CasualtyCause> CasualtyCauses { get; set; }
    }
}