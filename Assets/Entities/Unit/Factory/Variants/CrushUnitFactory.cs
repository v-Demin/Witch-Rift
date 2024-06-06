using System;
using UnityEngine;

public class CrushUnitFactory : AbstractUnitFactory
{
    [SerializeField] private Transform _spawnPosition;
    protected override Vector3 GetSpawnPosition => _spawnPosition.position;

    public override Unit CreateUnit()
    {
        var basis = CreateBasis();
        AttachComponent<TestingUnityComponent>(basis);
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
