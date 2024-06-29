using UnityEngine;

public class MovingTwoSidedBody : AbstractBody
{
    [SerializeField] private GameObject _leftBodyPart;
    [SerializeField] private GameObject _rightBodyPart;

    public override void HandleMoved(Vector3 delta)
    {
        if (delta.x > 0)
        {
            RotateRight();
        }
        else
        {
            RotateLeft();
        }
    }

    private void RotateLeft()
    {
        _leftBodyPart.SetActive(true);
        _rightBodyPart.SetActive(false);
    }

    private void RotateRight()
    {
        _leftBodyPart.SetActive(false);
        _rightBodyPart.SetActive(true);
    }
}
