using System.Collections.Generic;

public class Unit
{
    public Unit(List<AbstractUnitComponent> components)
    {
        components.ForEach(component => component.SetOwner(this));
    }
}
