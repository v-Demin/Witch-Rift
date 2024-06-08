using UnityEngine;

public class CrushUnitFactory : AbstractUnitFactory
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private AbstractBody _body;
    protected override Vector3 GetSpawnPosition => _spawnPosition.position;

    public override Unit CreateUnit()
    {
        var basis = CreateBasis();
        AttachComponent<TestingUnityComponent>(basis);
        AttachComponent<RandomMovingComponent>(basis);
        AttachComponent(basis, _body);
        return basis;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateUnit();
        }
    }
}
