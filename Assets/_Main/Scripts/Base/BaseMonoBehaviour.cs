using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMonoBehaviour : MonoBehaviour
{
    private void Reset()
    {
        LoadComponent();
        SetDefaultValue();
    }

    protected virtual void LoadComponent()
    {

    }

    protected abstract void SetDefaultValue();
}
