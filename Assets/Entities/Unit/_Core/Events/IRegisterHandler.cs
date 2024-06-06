public interface IRegisterHandler : ISubscriber
{
    void HandleRegisterRequest(AbstractUnitComponent component);
}
