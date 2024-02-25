using UnityEngine;

public class CameraAI : UnitComponent<CameraAIData>, IMarkerHandler
{
    public void AddMarker(CameraMarker marker)
    {
        Data.Markers.Add(marker);
        Owner.LocalEventHolder.Subscribe(this);
    }

    public void HandlePositionChanged(CameraMarker marker, Vector3 newPosition)
    {
        Owner.LocalEventHolder.RaiseEvent<IMovingEventCommandHandler>(handler => handler.MoveTo(newPosition));
    }

    public void HandlePriorityChanged(CameraMarker marker, int newPriority)
    {
    }
}
