using UnityEngine;

public abstract class AbstractUnitFactory : MonoBehaviour
{
    public abstract Unit CreateUnit();
    protected abstract Vector3 GetSpawnPosition { get; }

    protected Unit CreateBasis()
    {
        var basis = new GameObject();
        basis.transform.position = GetSpawnPosition;
        var unit = basis.AddComponent<Unit>();
        unit.Init();

        return unit;
    }

    protected void AttachComponent<T>(Unit owner) where T : AbstractUnitComponent
    {
        var componentGameObject = new GameObject();
        componentGameObject.transform.SetParent(owner.transform);
        var component = componentGameObject.AddComponent<T>();
        
        "вызов пришел".Log(Color.cyan);
        owner.InnerBus.RaiseEvent<IRegisterHandler>(handler => handler.HandleRegisterRequest(component));
    }
}
