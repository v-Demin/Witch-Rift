public abstract class UnitComponent<TData> : UnitComponent
    where TData : UnitComponentData
{
    private TData _data;
    public TData Data => _data; 

    public UnitComponent SetData(TData data)
    {
        _data = data;
        return this;
    }
}

public abstract class UnitComponent
{
    private Unit _owner;
    public Unit Owner => _owner;
    
    public UnitComponent SetOwner(Unit owner)
    {
        _owner = owner;
        Prepare();
        return this;
    }
    
    protected virtual void Prepare() { }

    public void Init()
    {
        Owner.LocalEventHolder.Subscribe(this);
        InitInner();
    }

    protected virtual void InitInner() { }
}
