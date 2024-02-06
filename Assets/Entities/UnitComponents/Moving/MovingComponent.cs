using UnityEngine;

public class MovingComponent : UnitComponent<MovingData, MovingEvents>
{
    public override void Init()
    {
        base.Init();
        
        Eventer.OnUnitDirectionChanged(Vector2.one);
    }
}
