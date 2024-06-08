using UnityEngine;

public interface IMovingRequestHandler : ISubscriber
{
    void HandleMovingRequest(Vector3 delta);
}
