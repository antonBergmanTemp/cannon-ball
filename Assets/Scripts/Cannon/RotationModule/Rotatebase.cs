using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Rotatebase : RotateAxis
{
    [SerializeField]
    private Transform axis;

    [SerializeField]
    private Vector2 current;

    [SerializeField] private RotationRange rotationRange;


    

    void Awake()
    {
        ApplyRotation();
        
    }

    void ApplyRotation()
    {
        axis.rotation = Quaternion.Euler(current.y * 100, current.x * 50, 0);
    }

    public override void Rotate(Vector2 vector)
    {
        vector.y = rotationRange.IsMax(current.y + vector.y) ? vector.y : 0;

        current += vector;
        ApplyRotation();
    }
}



[Serializable]
public struct RotationRange
{
    public float min;
    public float max;

    public bool IsMax(float value)
    {
        return value >= min && value <= max;
    }
}

