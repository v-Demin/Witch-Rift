using UnityEngine;

public interface IMovingEventCommandHandler : ISubscriber
{
    void Move(Vector2 delta);
    void MoveTo(Vector2 endPosition);
    void AdditionalMoveActionStarted();
    void AdditionalMoveActionStopped();
}
