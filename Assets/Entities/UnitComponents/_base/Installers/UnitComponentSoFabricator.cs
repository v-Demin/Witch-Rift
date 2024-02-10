using UnityEngine;

public abstract class UnitComponentSoInstaller<TComponent, TData> : UnitComponentSoInstaller<TComponent>
    where TComponent : UnitComponent<TData>, new()
    where TData : UnitComponentData
{
    [SerializeField] private TData _data;

    public override UnitComponent Fabricate()
    {
        return new TComponent().SetData(_data);
    }
}

public abstract class UnitComponentSoInstaller<TComponent> : UnitComponentSoInstaller
    where TComponent : UnitComponent, new()
{
    public override UnitComponent Fabricate()
    {
        return new TComponent();
    }
}

public abstract class UnitComponentSoInstaller : ScriptableObject
{
    public abstract UnitComponent Fabricate();
}
