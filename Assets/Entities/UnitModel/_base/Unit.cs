using System.Collections.Generic;

public class Unit
{
    private EventHolder _eventHolder = new ();
    public EventHolder EventHolder => _eventHolder;

    public Unit(List<UnitComponent> components)
    {
        components.ForEach(component => component.SetOwner(this));
        components.ForEach(component => component.Init());
    }
}
