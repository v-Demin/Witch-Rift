using UnityEngine;

public interface IMovingEventHandler : ISubscriber
{
    void HandleUnitMoving(Vector2 delta);
    void HandleMovingDirectionChanged(Vector2 normalizedDirection);
}
