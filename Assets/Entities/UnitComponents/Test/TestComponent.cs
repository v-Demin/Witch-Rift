using UnityEngine;

public class TestComponent : UnitComponent<TestData>
{
    protected override void InitWithOwner()
    {
        Data.TestText.Log(Color.cyan);
        Owner.Log(Color.cyan);
    }
}
