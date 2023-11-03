using UnityEngine;

public abstract class BaseSpawnDB : BaseMonoBehaviour
{
    [Header("Base Spawn")]
    [SerializeField] protected BaseListItemData _database;
    [SerializeField] protected BaseHoldersDB _baseHolders = null;
    [SerializeField] protected Transform _point = null;
    [SerializeField] protected string _pathFolder = "Folder Database asset" + Const.Prefix.ASSETS;

    protected void Spawn(int id)
    {
        Transform gameObject = _baseHolders.Get(id);
        if (gameObject == null)
        {
            Transform findObject = FindDatabaseById(id);
            if(findObject != null)
            {
                Transform clone = Clone(findObject);
                //clone.GetComponent<NetworkObject>().Spawn();
                clone.position = _point.position;
                clone.GetComponent<Id>()._Id = id;
                clone.SetParent(_baseHolders.transform);
            }
        }
    }

    protected void Spawn(int id, Vector3 point)
    {
        Transform gameObject = _baseHolders.Get(id);
        if (gameObject == null)
        {
            Transform findObject = FindDatabaseById(id);
            if (findObject != null)
            {
                Transform clone = Clone(findObject);
                //clone.GetComponent<NetworkObject>().Spawn();
                clone.position = point;
                clone.GetComponent<Id>()._Id = id;
                clone.SetParent(_baseHolders.transform);
            }
        }
    }

    protected Transform FindDatabaseById(int id)
    {
        if (_database._ListItemData.ContainsKey(id))
        {
            return _database._ListItemData[id]._itemInfo.prefab;
        }
        return null;
    }

    protected void Release(int key, Transform value)
    {
        _baseHolders.Release(key, value);
    }

    private Transform Clone(Transform item)
    {
        return Instantiate(item);
    }

    protected override void SetDefaultValue()
    {
        LoadHolder();
        LoadPoint();
    }

    protected void LoadHolder()
    {
        _baseHolders = transform.Find(Const.Spawn.HOLDERS).GetComponent<BaseHoldersDB>();
    }

    protected void LoadPoint()
    {
        _point = transform.Find(Const.Spawn.POINT);
    }
}