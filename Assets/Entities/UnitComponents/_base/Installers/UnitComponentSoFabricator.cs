using UnityEngine;

public abstract class UnitComponentSoFabricator<TComponent, TData> : UnitComponentSoFabricator<TComponent>
    where TComponent : UnitComponent<TData>, new()
    where TData : UnitComponentData
{
    [SerializeField] private TData _data;

    public override UnitComponent Fabricate()
    {
        return new TComponent().SetData(_data);
    }
}

public abstract class UnitComponentSoFabricator<TComponent> : AbstractUnitComponentSoFabricator
    where TComponent : UnitComponent, new()
{
    public override UnitComponent Fabricate()
    {
        return new TComponent();
    }
}

public abstract class AbstractUnitComponentSoFabricator : ScriptableObject
{
    public abstract UnitComponent Fabricate();
}
