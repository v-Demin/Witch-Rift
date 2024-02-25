using UnityEngine;

public interface IMarkerHandler : ISubscriber
{
    void AddMarker(CameraMarker marker);
    void HandlePositionChanged(CameraMarker marker, Vector3 newPosition);
    void HandlePriorityChanged(CameraMarker marker, int newPriority);
}
