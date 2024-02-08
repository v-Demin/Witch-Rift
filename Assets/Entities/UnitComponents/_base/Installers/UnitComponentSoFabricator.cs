using UnityEngine;

public abstract class UnitComponentSoFabricator<TComponent, TData> : AbstractUnitComponentSoFabricator
    where TComponent : UnitComponent<TData>, new()
    where TData : UnitComponentData
{
    [SerializeField] private TData _data;

    public override AbstractUnitComponent Fabricate()
    {
        return new TComponent().SetData(_data);
    }
}

public abstract class AbstractUnitComponentSoFabricator : ScriptableObject
{
    public abstract AbstractUnitComponent Fabricate();
}
