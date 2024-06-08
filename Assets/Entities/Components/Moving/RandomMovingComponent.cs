using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMovingComponent : AbstractUnitComponent
{
    private Transform _movingRoot;

    private void Start()
    {
        _movingRoot = transform.parent;
    }

    private void Update()
    {
        var movingDelta =  new Vector3(
            Random.Range(-1f * Time.deltaTime, 1f * Time.deltaTime),
            Random.Range(-1f * Time.deltaTime, 1f * Time.deltaTime),
            0f);
        
        _movingRoot.position += movingDelta;
        
        OwnerBus.RaiseEvent<IMovingHandler>(handler => handler.HandleMoved(movingDelta));
    }
}
