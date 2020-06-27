namespace FishManager.Domain.Services.Application
{
    public interface IFishManagerApplicationServiceCollection
    {
        ICasualtyService CasualtyService { get; }
        ISpeciesService SpeciesService { get; }
    }
}