using UnityEngine;

public interface IMovingEventCommandHandler : ISubscriber
{
    void Move(Vector2 delta);
}
