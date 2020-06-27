namespace FishManager.Domain.Services.Miscelleanous
{
    public interface IMapper
    {
        T Map<T>(object source);
    }
}