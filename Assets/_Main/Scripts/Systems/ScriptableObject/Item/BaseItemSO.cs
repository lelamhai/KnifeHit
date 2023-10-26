using UnityEngine;

public abstract class BaseItemSO : ScriptableObject
{
    public BaseAttributeSO _BaseAttributeSO;

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

[System.Serializable]
public class BaseAttributeSO
{
    public int id;
    public string name;
    public Sprite avatar;
    [TextArea(5, 500)]
    public string description;
    public int price;
}