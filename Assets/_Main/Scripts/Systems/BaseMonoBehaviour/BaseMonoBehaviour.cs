using UnityEngine;

public abstract class BaseMonoBehaviour : MonoBehaviour
{
    private void Reset()
    {
        SetDefaultValue();
    }

    protected abstract void SetDefaultValue();
}
