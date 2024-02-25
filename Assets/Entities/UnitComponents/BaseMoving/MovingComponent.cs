using UnityEngine;
using Zenject;

public class MovingComponent : UnitComponent<MovingData>, IMovingEventCommandHandler, ITickable
{
    [Inject] private readonly TickableManager _tickableManager;
    
    protected override void Prepare()
    {
        _tickableManager.Add(this);
        Owner.LocalEventHolder.Subscribe<IMovingEventCommandHandler>(this);
    }

    public void Move(Vector2 delta)
    {
        Data.Rigidbody.velocity = delta * Data.MoveSpeed;
        Owner.Name.Log(Color.cyan);
    }

    public void MoveTo(Vector2 endPosition)
    {
        Data.Rigidbody.position = endPosition;
        Owner.Name.Log(Color.green);
    }

    public void AdditionalMoveActionStarted()
    {
    }

    public void AdditionalMoveActionStopped()
    {
    }

    public void Tick()
    {
        if (Data.Rigidbody.velocity == Vector2.zero) return;
        
        Owner.LocalEventHolder.RaiseEvent<IMovingEventHandler>(handler => handler.HandleUnitMoving(Data.Rigidbody.velocity));
        Owner.LocalEventHolder.RaiseEvent<IMovingEventHandler>(handler => handler.HandleMovingDirectionChanged(Data.Rigidbody.velocity.normalized));
    }
}
