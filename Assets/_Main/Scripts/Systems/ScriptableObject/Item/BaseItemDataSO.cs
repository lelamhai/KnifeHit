using UnityEngine;

public abstract class BaseItemDataSO : ScriptableObject
{
    public ItemInfo _itemInfo;

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
public class ItemInfo
{
    public int id;
    public string name;
    public Sprite avatar;
    [TextArea(5, 500)]
    public string description;
    public int price;
    public Transform prefab;
}