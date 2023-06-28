using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpawn : BaseMonoBehaviour
{
    [Header("Base Spawn")]
    [SerializeField] protected BasePrefabs _basePrefabs = null;
    [SerializeField] protected BaseHolders _baseHolders = null;

    public void SpawnGameObject(string name, Vector3 point)
    {
        if (_baseHolders.CountPool(name) > 0)
        {
            Transform undoGameObject = _baseHolders.UndoGameObject(name);
            if (undoGameObject == null) return;
            SetUndoGameObject(undoGameObject, name, point);
            RemoveGameObjectPool(undoGameObject);
        } else
        {
            Transform cloneGameObject = _basePrefabs.CloneGameObject(name);
            if (cloneGameObject == null) return;
            SetUndoGameObject(cloneGameObject, name, point);
        }
    }

    private void SetUndoGameObject(Transform gameObject, string name, Vector3 point)
    {
        gameObject.SetPositionAndRotation(point, Quaternion.identity);
        gameObject.gameObject.SetActive(true);
        gameObject.name = name;
        gameObject.SetParent(_baseHolders.transform);
    }

    protected override void LoadComponent()
    {
        Transform prefab = transform.Find("Prefabs");
        _basePrefabs = prefab.GetComponent<BasePrefabs>();

        Transform holder = transform.Find("Holders");
        _baseHolders = holder.GetComponent<BaseHolders>();
    }

    public void AddGameObjectPool(Transform gameobject)
    {
        _baseHolders.AddObjectPool(gameobject);
    }

    public void RemoveGameObjectPool(Transform gameobject)
    {
        _baseHolders.RemoveObjectPool(gameobject);
    }
}
