using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Shootbase shootbase;

    public Vector2 InputRotation = new Vector2();

    public void Update()
    {
        InputRotation = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime;
    }
}
   
