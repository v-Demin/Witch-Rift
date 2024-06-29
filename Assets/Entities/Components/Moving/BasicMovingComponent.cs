using UnityEngine;

public class BasicMovingComponent : AbstractUnitComponent, IMovingRequestHandler
{
    private Transform _movingRoot;

    private void Start()
    {
        _movingRoot = transform.parent;
    }

    public void HandleMovingRequest(Vector3 delta)
    {
        _movingRoot.position += delta * Time.deltaTime;

        OwnerBus.RaiseEvent<IMovingHandler>(handler => handler.HandleMoved(delta));
    }
}
