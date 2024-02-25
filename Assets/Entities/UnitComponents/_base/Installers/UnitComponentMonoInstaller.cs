using UnityEngine;
using Zenject;

public abstract class UnitComponentMonoInstaller<TComponent, TData> : AbstractUnitComponentMonoInstaller
    where TComponent : UnitComponent<TData>, new()
    where TData : UnitComponentData
{
    [SerializeField] private TData _data;

    public override UnitComponent Fabricate(DiContainer container)
    {
        return container.Instantiate<TComponent>().SetData(_data);
    }
}

public abstract class AbstractUnitComponentMonoInstaller : MonoBehaviour
{
    public abstract UnitComponent Fabricate(DiContainer container);
}
