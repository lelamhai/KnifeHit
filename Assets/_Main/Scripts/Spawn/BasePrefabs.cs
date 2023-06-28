using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePrefabs : BaseMonoBehaviour
{
    [Header("Base Prefabs")]
    [SerializeField] protected List<Transform> _listPrefabs = new List<Transform>();
    protected override void LoadComponent()
    {
        AddPrefabs();
    }

    protected virtual void AddPrefabs()
    {
        Transform PrefabGameObject = this.transform;
        foreach (Transform item in PrefabGameObject)
        {
            _listPrefabs.Add(item);
            item.gameObject.SetActive(false);
        }
    }

    public Transform CloneGameObject(string name)
    {
        foreach (var item in _listPrefabs)
        {
            if (item.name.Equals(name))
            {
                return Instantiate(item);
            }
        }
        return null;
    }
}
