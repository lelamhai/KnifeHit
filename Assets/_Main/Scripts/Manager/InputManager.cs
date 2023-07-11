using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : Singleton<InputManager>
{
    public UnityAction _Shooting;
    public UnityAction<Vector3> _Movement;


    public void Movement(Vector3 pos)
    {
        _Movement?.Invoke(pos);
    }

    public void Shooting()
    {
        _Shooting?.Invoke();
    }

    protected override void SetDefaultValue()
    {}
}
