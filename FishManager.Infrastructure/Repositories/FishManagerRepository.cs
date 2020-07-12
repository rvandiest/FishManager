using FishManager.Domain.Entities;
using FishManager.Domain.Repositories;
using FishManager.Infrastructure.Contexts;

namespace FishManager.Infrastructure.Repositories
{
    public class FishManagerRepository : IFishManagerRepository
    {
        public FishManagerRepository(FishManagerContext context)
        {
            Species = new SpeciesRepository(context);
            Tanks = new TankRepository(context);
            Casualties = new CasualtyRepository(context);
            CasualtyCauses = new CasualtyCauseRepository(context);
        }

        public IRepository<Species> Species { get; private set; }

        public IRepository<Tank> Tanks { get; private set; }

        public IRepository<Casualty> Casualties { get; private set; }

        public IRepository<CasualtyCause> CasualtyCauses { get; private set; }
    }
}