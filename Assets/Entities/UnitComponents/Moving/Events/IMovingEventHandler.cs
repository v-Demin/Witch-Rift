using UnityEngine;

public interface IMovingEventHandler : ISubscriber
{
    void HandleUnitMoving(Vector2 delta);
    void HandleUnitDirectionChanged(Vector2 normalizedDirection);
}
