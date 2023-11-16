using System.IO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trunk Database", menuName = "Knife/Database/Trunk/TrunkDatabase")]
public class TrunkDatabase : BaseDatabase
{
    public GenericDictionary<int, ItemTrunkDatabase> Database = new GenericDictionary<int, ItemTrunkDatabase>();

    protected override void LoadScriptableObject()
    {
#if UNITY_EDITOR
        _path = Path.Combine(Const.Path.PROJECT_FOLDER, Const.Path.PATH_SCRIPTOBJECT, _pathFolder);
        _pathAsset = Path.Combine(Const.Path.PATH_SCRIPTOBJECT, _pathFolder);
        var info = new DirectoryInfo(_path);
        var fileInfo = info.GetFiles("*" + Const.Prefix.ASSETS, SearchOption.AllDirectories);

        for (int i = 0; i < fileInfo.Length; i++)
        {
            ItemTrunkDatabase gameObject = (ItemTrunkDatabase)AssetDatabase.LoadAssetAtPath(_pathAsset + fileInfo[i].Name, typeof(ItemTrunkDatabase));
            if (gameObject == null)
            {
                Debug.Log("The trunk is null", this);
                return;
            }
            gameObject.Model.Id = i;
            Database.Add(i, gameObject);
        }
#endif
    }

    protected override void SetDefaultValue()
    {
        _pathFolder = "Trunk/Items/";
    }
}