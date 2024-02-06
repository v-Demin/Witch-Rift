public abstract class AbstractUnitEventer
{
    protected EventHolder Holder;
        
    public void Init(EventHolder holder)
    {
        Holder = holder;
        Register();
    }

    private void Register()
    {
        Holder.Subscribe(this);
    }
}
