using System.Collections.Generic;
using UnityEngine;

public class HoldersKnife : BaseMonoBehaviour
{
    [SerializeField] protected GenericDictionary<int, List<Transform>> _poolObject = new GenericDictionary<int, List<Transform>>();
    public GenericDictionary<int, List<Transform>> PoolObject
    {
        get => _poolObject;
    }

    public int GetCountById(int id)
    {
        if (_poolObject.ContainsKey(id))
        {
            return _poolObject[id].Count;
        }
        return 0;
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

    public void BackHolder(int key)
    {
        List<Transform> list = _poolObject[key];
        foreach (var item in list)
        {
            item.SetParent(this.transform);
            SetActive(item, false);
        }
    }

    public List<Transform> GetById(int key)
    {
        List<Transform> list = _poolObject[key];
        return list;
    }

    public void Clear()
    {
        _poolObject.Clear();
    }

    private void SetActive(Transform go, bool active)
    {
        go.gameObject.SetActive(active);
    }

    protected override void SetDefaultValue()
    { }
}