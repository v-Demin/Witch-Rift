using UnityEngine;

public class MovingComponent : UnitComponent<MovingData>, IMovingEventCommandHandler
{
    protected override void Prepare()
    {
        base.Prepare();
        
        Owner.EventHolder.Subscribe<IMovingEventCommandHandler>(this);
    }

    public void Move(Vector2 delta)
    {
        Data.Rigidbody.velocity = delta * Data.MoveSpeed;
        
        Owner.EventHolder.RaiseEvent<IMovingEventHandler>(handler => handler.HandleUnitMoving(Data.Rigidbody.velocity));
        Owner.EventHolder.RaiseEvent<IMovingEventHandler>(handler => handler.HandleMovingDirectionChanged(Data.Rigidbody.velocity.normalized));
    }
}
