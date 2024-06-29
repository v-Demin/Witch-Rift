using UnityEngine;

public class CrushUnitFactory : AbstractUnitFactory
{
    [SerializeField] private string _teamID;
    [SerializeField] private Camera _camera;
    [SerializeField] private AbstractBody _body;

    //[Todo]: запрос спавна в позиции и создание понятия "паттерн" и "боевой сценарий"
    protected override Vector3 GetSpawnPosition => GetRandomPointOutsideCamera();

    public override Unit CreateUnit()
    {
        var basis = CreateBasis();
        AttachComponent<TestingUnityComponent>(basis);
        AttachComponent<BasicMovingComponent>(basis);
        AttachComponent<TeamComponent>(basis).TeamID = _teamID;
        AttachComponent<UnitVisionComponent>(basis);
        AttachComponent<CrushAI>(basis);
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
    
    Vector3 GetRandomPointOutsideCamera()
    {
        var cameraBottomLeft = _camera.ViewportToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));
        var cameraTopRight = _camera.ViewportToWorldPoint(new Vector3(1, 1, _camera.nearClipPlane));

        var side = Random.Range(0, 4);

        var randomPoint = side switch
        {
            0 => new Vector3(Random.Range(cameraBottomLeft.x - 1, cameraTopRight.x + 1), cameraTopRight.y + 1, 0),
            1 => new Vector3(Random.Range(cameraBottomLeft.x - 1, cameraTopRight.x + 1), cameraBottomLeft.y - 1, 0),
            2 => new Vector3(cameraBottomLeft.x - 1, Random.Range(cameraBottomLeft.y - 1, cameraTopRight.y + 1), 0),
            3 => new Vector3(cameraTopRight.x + 1, Random.Range(cameraBottomLeft.y - 1, cameraTopRight.y + 1), 0),
            _ => Vector3.zero
        };

        return randomPoint;
    }
}
