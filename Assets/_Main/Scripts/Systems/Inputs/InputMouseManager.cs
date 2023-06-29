using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMouseManager : MonoBehaviour
{
    private void Update()
    {
        MouseLeft();
        MouseRight();
    }

    private void MouseRight()
    {
        GetMouseButtonUpRight();
        GetMouseButtonDownRight();
    }

    private void MouseLeft()
    {
        GetMouseButtonDownLeft();
        GetMouseButtonUpLeft();
    }

    private void GetMouseButtonUpLeft()
    {
        if (Input.GetMouseButtonUp(0))
        {

        }
    }

    private void GetMouseButtonDownLeft()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }

    private void GetMouseButtonUpRight()
    {
        if (Input.GetMouseButtonUp(1))
        {

        }
    }

    private void GetMouseButtonDownRight()
    {
        if (Input.GetMouseButtonUp(1))
        {

        }
    }
}
