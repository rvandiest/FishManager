using FishManager.Domain.Entities;

namespace FishManager.Domain.Repositories
{
    public interface IFishManagerRepository
    {
        IRepository<Species> Species { get; }
        IRepository<Tank> Tanks { get; }
        IRepository<Casualty> Casualties { get; }
        IRepository<CasualtyCause> CasualtyCauses { get; }
    }
}