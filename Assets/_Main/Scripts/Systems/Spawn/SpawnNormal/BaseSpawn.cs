using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpawn : BaseMonoBehaviour
{
    [Header("Base Spawn")]
    [SerializeField] protected BaseHolders _baseHolders = null;
    [SerializeField] protected Transform _prefab = null;
    [SerializeField] protected Transform _point = null;

    public void Spawn()
    {
        Transform gameObject = _baseHolders.Get();
        if (gameObject == null)
        {
            if (_prefab != null)
            {
                Transform clone = Clone(_prefab);
                if(_point != null)
                {
                    clone.position = _point.position;
                }
                clone.SetParent(_baseHolders.transform);
            }
        }
    }

    private Transform Clone(Transform item)
    {
        return Instantiate(item);
    }

    public void Release(Transform value)
    {
        _baseHolders.Release(value);
    }

    protected override void SetDefaultValue()
    {
        LoadHolder();
        LoadPoint();
    }

    protected void LoadHolder()
    {
        _baseHolders = transform.Find(Const.Spawn.HOLDERS).GetComponent<BaseHolders>();
    }

    protected void LoadPoint()
    {
        _point = transform.Find(Const.Spawn.POINT);
    }
}