using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHolders : BaseMonoBehaviour
{
    [Header("Base Holders")]
    [SerializeField] protected List<Transform> _listPoolObject = new List<Transform>();

    public void AddObjectPool(Transform gameObject)
    {
        _listPoolObject.Add(gameObject);
    }

    public void RemoveObjectPool(Transform gameObject)
    {
        foreach (Transform item in _listPoolObject)
        {
            if(gameObject == item)
            {
                _listPoolObject.Remove(item);
                return;
            }
        }
    }

    public int CountPool(string name)
    {
        foreach (var item in _listPoolObject)
        {
            if (item.name.Equals(name))
            {
                return 1;
            }
        }
        return 0;
    }

    public Transform UndoGameObject(string name)
    {
        foreach (var item in _listPoolObject)
        {
            if(item.name.Equals(name))
            {
                return item;
            }
        }
        return null;
    }
}
