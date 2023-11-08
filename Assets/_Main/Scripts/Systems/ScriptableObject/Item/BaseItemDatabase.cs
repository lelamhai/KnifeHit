using UnityEngine;

public abstract class BaseItemDatabase : ScriptableObject
{
    private void Awake()
    {
        SetInfo();
        SetPrefab();
    }

    private void Reset()
    {
        SetPrefab();
        SetInfo();
    }

    protected abstract void SetInfo();
    protected abstract void SetPrefab();
}