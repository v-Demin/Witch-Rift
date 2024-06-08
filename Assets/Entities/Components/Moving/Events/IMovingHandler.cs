using UnityEngine;

public interface IMovingHandler : ISubscriber
{
    void HandleMoved(Vector3 delta);
}
