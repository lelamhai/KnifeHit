using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputKeyboard : MonoBehaviour
{
    public Vector2 _MovementPos { get; private set; }

    private void Update()
    {
        Space();
        //Movement2D();
    }

    private void Movement2D()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        var z = 0;

        _MovementPos = new Vector3(x, y, z);
    }

    private void Space()
    {
        GetKeyDownSpace();
        GetKeyUpSpace();
    }

    private void GetKeyUpSpace()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
        }
    }

    private void GetKeyDownSpace()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            InputManager.Instance.Shooting();
        }
    }
}
