using UnityEngine;

public abstract class AbstractUnitComponent : MonoBehaviour, ISubscriber
{
    protected EventBus OwnerBus;
    protected EventBus InnerBus;
    
    public void Attach(EventBus ownerBus)
    {
        OwnerBus = ownerBus;
        OwnerBus.Subscribe(this);
    }
}
