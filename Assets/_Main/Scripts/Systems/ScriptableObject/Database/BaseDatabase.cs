using UnityEngine;

public abstract class BaseDatabase : ScriptableObject
{
    [SerializeField] protected string _pathFolder = string.Empty;
    protected string _path = string.Empty;
    protected string _pathAsset = string.Empty;

    private void Reset()
    {
        SetDefaultValue();
        LoadComponent();
    }

    protected void LoadComponent()
    {
        LoadScriptableObject();
    }

    protected abstract void SetDefaultValue();
    protected abstract void LoadScriptableObject();
}