using FishManager.Domain.Repositories;

namespace FishManager.Domain.Services.Application
{
    public class FishManagerApplicationServiceCollection : IFishManagerApplicationServiceCollection
    {
        public FishManagerApplicationServiceCollection(IFishManagerRepository repo)
        {
            CasualtyService = new CasualtyService(repo);
            SpeciesService = new SpeciesService(repo);
            SuggestionService = new SuggestionService(repo);
        }

        public ICasualtyService CasualtyService { get; private set; }
        public ISpeciesService SpeciesService { get; private set; }
        public ISuggestionService SuggestionService { get; private set; }
    }
}