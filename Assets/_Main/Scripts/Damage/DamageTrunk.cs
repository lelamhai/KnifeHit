using System.IO;
using UnityEditor;
using UnityEngine;

public class DamageTrunk : BaseDamage
{
    [SerializeField] private ItemTrunkDatabase _data;
    protected string _pathFile = string.Empty;
    protected string _pathAsset = string.Empty;
    private void Awake()
    {
        _damage = _data.Model.Damage;
    }

    protected override void SetDefaultValue()
    {
#if UNITY_EDITOR
        _pathFile = "Trunk/Items/ItemTrunk00.asset";
        _pathAsset = Path.Combine(Const.Path.PATH_SCRIPTOBJECT, _pathFile);

        _data = (ItemTrunkDatabase)AssetDatabase.LoadAssetAtPath(_pathAsset, typeof(ItemTrunkDatabase));
        _damage = _data.Model.Damage;
#endif
    }
}