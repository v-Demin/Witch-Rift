using UnityEngine;

public abstract class AbstractBody : AbstractUnitComponent, IMovingHandler
{
    public abstract void HandleMoved(Vector3 delta);
}
