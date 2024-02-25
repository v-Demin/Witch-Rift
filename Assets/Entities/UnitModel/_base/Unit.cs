using System.Collections.Generic;

public class Unit
{
    public EventHolder LocalEventHolder => _localEventHolder;
    private EventHolder _localEventHolder = new ();

    public string Name;
    
    public Unit()
    {
    }
    
    public Unit(List<UnitComponent> components)
    {
        AddComponents(components);
    }

    public void AddComponent(UnitComponent component)
    {
        component.SetOwner(this);
        component.Init();
    }

    public void AddComponents(List<UnitComponent> components)
    {
        components.ForEach(component => component.SetOwner(this));
        components.ForEach(component => component.Init());
    }
}
