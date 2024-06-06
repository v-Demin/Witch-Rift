using UnityEngine;

public abstract class AbstractUnitComponent : MonoBehaviour
{
    protected EventBus OwnerBus;
    protected EventBus InnerBus;
    
    public void Attach(EventBus ownerBus)
    {
        OwnerBus = ownerBus;
        "аттач".Log(Color.cyan);
    }
}
