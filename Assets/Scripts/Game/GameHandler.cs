using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler GameInstance;

    public PlayerInput InputModule;

    private PlayerInput s_inpout, fdfdfd;

    public Rotatebase RotationModule;
    public Shootbase shootModule;

    public UIHandler uiModule;

    void Awake()
    {
        GameInstance = this;
    }

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
