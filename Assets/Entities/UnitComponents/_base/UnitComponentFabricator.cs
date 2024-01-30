using UnityEngine;

public abstract class UnitComponentFabricator<TComponent, TData> : AbstractUnitComponentFabricator
    where TComponent : UnitComponent<TData>, new()
    where TData : UnitComponentData
{
    [SerializeField] private TData _data;

    public override AbstractUnitComponent Fabricate()
    {
        return new TComponent().SetData(_data);
    }
}

public abstract class AbstractUnitComponentFabricator : ScriptableObject
{
    public abstract AbstractUnitComponent Fabricate();
}
