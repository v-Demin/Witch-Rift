using UnityEngine;

public abstract class UnitComponentMonoFabricator<TComponent, TData> : AbstractUnitComponentMonoFabricator
    where TComponent : UnitComponent<TData>, new()
    where TData : UnitComponentData
{
    [SerializeField] private TData _data;

    public override AbstractUnitComponent Fabricate()
    {
        return new TComponent().SetData(_data);
    }
}

public abstract class AbstractUnitComponentMonoFabricator : MonoBehaviour
{
    public abstract AbstractUnitComponent Fabricate();
}
