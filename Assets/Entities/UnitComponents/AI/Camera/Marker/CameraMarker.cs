using UnityEngine;
using Zenject;

public class CameraMarker : UnitComponent<CameraMarkerData>, IPositionChangedHandler
{
    [Inject(Id = "Camera")] private readonly EventHolder _cameraHolder;
    
    protected override void Prepare()
    {
        Owner.LocalEventHolder.Subscribe(this);
        _cameraHolder.RaiseEvent<IMarkerHandler>(handler => handler.AddMarker(this));
    }

    public void HandlePositionChanged(Vector3 newPosition)
    {
        "MarkerCheck".Log(Color.green);
        Data.WorldPosition = newPosition;
        _cameraHolder.RaiseEvent<IMarkerHandler>(handler => handler.HandlePositionChanged(this, newPosition));
    }
}
