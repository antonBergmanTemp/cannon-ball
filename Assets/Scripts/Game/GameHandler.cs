using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    
    public PlayerInput InputModule;

    public Rotatebase RotationModule;
    public Shootbase shootModule;

    public UIHandler uiModule;

    public void Update()
    {
        RotationModule.Rotate(InputModule.InputRotation);
        KeyBoardInput();
    }

    private void KeyBoardInput()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            shootModule.Shoot();
        }
    }
}
