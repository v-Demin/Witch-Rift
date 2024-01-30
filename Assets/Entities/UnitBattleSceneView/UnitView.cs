using UnityEngine;

public class UnitView : MonoBehaviour
{
    private Unit _owner;
    
    public void Init(Unit owner)
    {
        _owner = owner;
    }
}
