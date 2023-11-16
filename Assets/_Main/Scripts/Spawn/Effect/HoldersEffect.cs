using System.Collections.Generic;
using UnityEngine;

public class HoldersEffect : BaseMonoBehaviour
{
    [SerializeField] protected GenericDictionary<int, List<Transform>> _poolObject = new GenericDictionary<int, List<Transform>>();

    public void Add(int key, Transform value)
    {
        if (_poolObject.ContainsKey(key))
        {
            List<Transform> list = _poolObject[key];
            list.Add(value);
        }
        else
        {
            List<Transform> list = new List<Transform>();
            list.Add(value);
            this._poolObject.Add(key, list);
        }
        SetActive(value, true);
    }

    public Transform Get(int id)
    {
        if (_poolObject.ContainsKey(id))
        {
            foreach (Transform item in _poolObject[id])
            {
                if (!item.gameObject.activeInHierarchy)
                {
                    SetActive(item, true);
                    return item;
                }
            }
        }
        return null;
    }

    public void Release(int key, Transform value)
    {
        if (_poolObject.ContainsKey(key))
        {
            List<Transform> list = _poolObject[key];
            list.Add(value);
        }
        else
        {
            List<Transform> list = new List<Transform>();
            list.Add(value);
            this._poolObject.Add(key, list);
        }
        SetActive(value, false);
    }

    public void Clear()
    {
        _poolObject.Clear();
    }

    private void SetActive(Transform prefab, bool active)
    {
        prefab.gameObject.SetActive(active);
    }

    protected override void SetDefaultValue()
    {}
}