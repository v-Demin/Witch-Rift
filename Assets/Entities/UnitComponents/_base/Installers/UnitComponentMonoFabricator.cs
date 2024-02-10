using UnityEngine;

public abstract class UnitComponentMonoFabricator<TComponent, TData> : AbstractUnitComponentMonoFabricator
    where TComponent : UnitComponent<TData>, new()
    where TData : UnitComponentData
{
    [SerializeField] private TData _data;

    public override UnitComponent Fabricate()
    {
        return new TComponent().SetData(_data);
    }
}

public abstract class AbstractUnitComponentMonoFabricator : MonoBehaviour
{
    public abstract UnitComponent Fabricate();
}
