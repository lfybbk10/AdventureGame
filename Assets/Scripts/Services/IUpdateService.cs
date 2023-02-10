
public interface IUpdateService : IService
{
    void AddService(IUpdatableService service);
    void RemoveService(IUpdatableService service);
}
