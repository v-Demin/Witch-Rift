using UnityEngine;

public abstract class AbstractBody : AbstractUnitComponent, IMovingHandler
{
    [SerializeField] protected Collider2D Collider;

    public EventBus BodyBus => OwnerBus;
    public abstract void HandleMoved(Vector3 delta);
}
