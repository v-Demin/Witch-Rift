public abstract class UnitComponent<TData> : AbstractUnitComponent
    where TData : UnitComponentData
{
    private TData _data;
    public TData Data => _data; 

    public AbstractUnitComponent SetData(TData data)
    {
        _data = data;
        InitWithData();
        return this;
    }
    protected virtual void InitWithData() { }

}

public abstract class AbstractUnitComponent
{
    private Unit _owner;
    public Unit Owner => _owner;
    
    public AbstractUnitComponent SetOwner(Unit owner)
    {
        _owner = owner;
        InitWithOwner();
        return this;
    }
    
    protected abstract void InitWithOwner();
}
