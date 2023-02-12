
using Zenject;

public abstract class UpdatableService : IUpdatableService
{
    protected UpdatableService(IUpdateService updateService)
    {
        updateService.AddService(this);
    }

    public virtual void Update(){}
    public virtual void FixedUpdate(){}
}
