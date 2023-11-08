using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHolders : BaseMonoBehaviour
{
    [Header("Base Holders")]
    [SerializeField] protected Queue<Transform> _poolObject = new Queue<Transform>();

    public Transform Get()
    {
        foreach (Transform item in _poolObject)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                SetActive(item, true);
                return item;
            }
        }
        return null;
    }

    public Transform GetItemByIndex(int id)
    {
        return transform.GetChild(id);
    }

    public void Release(Transform value)
    {
        _poolObject.Enqueue(value);
        SetActive(value, false);
    }

    public void Clear()
    {
        _poolObject.Clear();
    }

    private void SetActive(Transform go, bool active)
    {
        go.gameObject.SetActive(active);
    }
}