using UnityEngine;

public class PositionTrackerComponent : UnitComponent<PositionTrackerData>, IMovingEventHandler
{
    //[Todo]: список с поиском позиций: ближайшие противники, дальние противники, сильнейшие противники, самые раненные противники, самые крупные группы противников, текущий поворот (либо мышь, либо последнее направление движения)
    protected override void Prepare()
    {
        Owner.LocalEventHolder.Subscribe(this);
    }

    public void HandleUnitMoving(Vector2 delta)
    {
        Owner.LocalEventHolder.RaiseEvent<IPositionChangedHandler>(handler =>
            handler.HandlePositionChanged(Data.Target.position));
    }

    public void HandleMovingDirectionChanged(Vector2 normalizedDirection)
    {
    }
}
