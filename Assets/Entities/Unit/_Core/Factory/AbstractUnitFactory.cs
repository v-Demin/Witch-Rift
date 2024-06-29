using UnityEngine;

public abstract class AbstractUnitFactory : MonoBehaviour
{
    public abstract Unit CreateUnit();
    protected abstract Vector3 GetSpawnPosition { get; }

    protected Unit CreateBasis()
    {
        var basis = new GameObject();
        var unit = basis.AddComponent<Unit>();
        unit.Init();
        
        basis.transform.position = GetSpawnPosition;

        return unit;
    }

    protected T AttachComponent<T>(Unit owner) where T : AbstractUnitComponent
    {
        var componentGameObject = new GameObject();
        componentGameObject.transform.SetParent(owner.transform, false);
        var component = componentGameObject.AddComponent<T>();
        
        owner.InnerBus.RaiseEvent<IRegisterHandler>(handler => handler.HandleRegisterRequest(component));
        return component;
    }
    
    protected T AttachComponent<T>(Unit owner, T prefab) where T : AbstractUnitComponent
    {
        var instance = Instantiate(prefab, owner.transform);
        owner.InnerBus.RaiseEvent<IRegisterHandler>(handler => handler.HandleRegisterRequest(instance));
        return instance;
    }
}
