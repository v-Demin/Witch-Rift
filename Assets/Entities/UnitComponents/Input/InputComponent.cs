using UnityEngine;
using UnityEngine.InputSystem;

public class InputComponent : UnitComponent, PlayerInput.IBaseActions
{
    private PlayerInput _inputActions = new PlayerInput();

    protected override void Prepare()
    {
        base.Prepare();
        
        _inputActions.Enable();
    }

    protected override void InitInner()
    {
        base.InitInner();

        _inputActions.Base.MovingDirectionAction.performed += OnMovingDirectionAction;
        _inputActions.Base.MovingDirectionAction.canceled += OnMovingDirectionAction;

        _inputActions.Base.AdditionalMovingAction.performed += OnAdditionalMovingAction;
    }

    public void OnMovingDirectionAction(InputAction.CallbackContext context)
    {
        Owner.EventHolder.RaiseEvent<IMovingEventCommandHandler>(handler => handler.Move(context.ReadValue<Vector2>()));
    }

    public void OnAdditionalMovingAction(InputAction.CallbackContext context)
    {
    }
}
