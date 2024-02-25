using UnityEngine;

public interface IPositionChangedHandler : ISubscriber
{
    void HandlePositionChanged(Vector3 newPosition);
}
