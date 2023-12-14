using UnityEngine;
using UnityEngine.Animations;

public class Rotatebase : RotateAxis
{
    [SerializeField]
    private Transform axis;

    [SerializeField]
    private Vector2 current;

    void Awake()
    {
        ApplyRotation();
    }

    void ApplyRotation()
    {
        axis.rotation = Quaternion.Euler(current.y, current.x, 0);
    }

    public override void Rotate(Vector2 vector)
    {
        current += vector;
        ApplyRotation();
    }
}