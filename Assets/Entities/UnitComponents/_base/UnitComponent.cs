public abstract class UnitComponent<TData, TEvent> : UnitComponent<TData>
    where TData : UnitComponentData
    where TEvent : AbstractUnitEventer, new()
{
    private TEvent _eventer = new ();
    public TEvent Eventer => _eventer;

    protected override void Prepare()
    {
        _eventer.Init(Owner.EventHolder);
    }
}

public abstract class UnitComponent<TData> : AbstractUnitComponent
    where TData : UnitComponentData
{
    private TData _data;
    public TData Data => _data; 

    public AbstractUnitComponent SetData(TData data)
    {
        _data = data;
        return this;
    }
}

public abstract class AbstractUnitComponent
{
    private Unit _owner;
    public Unit Owner => _owner;
    
    public AbstractUnitComponent SetOwner(Unit owner)
    {
        _owner = owner;
        Prepare();
        return this;
    }
    
    protected virtual void Prepare() { }
    public virtual void Init() { }
}
