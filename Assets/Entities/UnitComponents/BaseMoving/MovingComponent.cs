using UnityEngine;

public class MovingComponent : UnitComponent<MovingData>, IMovingEventCommandHandler
{
    public void Move(Vector2 delta)
    {
        Data.Rigidbody.velocity += delta;
    }
}
