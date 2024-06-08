using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IRegisterHandler
{
    public EventBus InnerBus = new EventBus();

    private List<AbstractUnitComponent> _registeredComponents = new List<AbstractUnitComponent>();

    public void Init()
    {
        InnerBus.Subscribe(this);
    }

    public void HandleRegisterRequest(AbstractUnitComponent component)
    {
        RegisterComponent(component);
    }

    private void RegisterComponent(AbstractUnitComponent component)
    {
        component.Attach(InnerBus);
        component.transform.SetParent(transform);
        _registeredComponents.Add(component);
    }
}
