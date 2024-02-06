using UnityEngine;

public class MovingEvents : AbstractUnitEventer, IMovingEventHandler
{
    public void OnUnitMoving(Vector2 delta)
    {
        Holder.RaiseEvent<IMovingEventHandler>(handler => handler.HandleUnitMoving(delta));
    }

    public void OnUnitDirectionChanged(Vector2 normalizedDirection)
    {
        Holder.RaiseEvent<IMovingEventHandler>(handler => handler.HandleUnitDirectionChanged(normalizedDirection));
    }

    public void HandleUnitMoving(Vector2 delta)
    {
        $"Словил HandleUnitMoving {delta}".Log(Color.green);
    }

    public void HandleUnitDirectionChanged(Vector2 normalizedDirection)
    {
        $"Словил HandleUnitDirectionChanged {normalizedDirection}".Log(Color.green);
    }
}
