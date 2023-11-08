using System.IO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Knifes Database", menuName = "Knife/Database/Knife/KnifesDatabase")]
public class KnifesDatabase : BaseDatabase
{
    public GenericDictionary<int, ItemKnifeDatabase> _Database = new GenericDictionary<int, ItemKnifeDatabase>();
    protected override void LoadScriptableObject()
    {
#if UNITY_EDITOR
        _path = Path.Combine(Const.Path.PROJECT_FOLDER, Const.Path.PATH_SCRIPTOBJECT, _pathFolder);
        _pathAsset = Path.Combine(Const.Path.PATH_SCRIPTOBJECT, _pathFolder);
        var info = new DirectoryInfo(_path);
        var fileInfo = info.GetFiles("*" + Const.Prefix.ASSETS, SearchOption.AllDirectories);

        for (int i = 0; i < fileInfo.Length; i++)
        {
            ItemKnifeDatabase gameObject = (ItemKnifeDatabase)AssetDatabase.LoadAssetAtPath(_pathAsset + fileInfo[i].Name, typeof(ItemKnifeDatabase));
            if (gameObject == null)
            {
                Debug.Log("Get null", this);
                return;
            }
            gameObject.Model.Id = i;
            _Database.Add(i, gameObject);
        }
#endif
    }

    protected override void SetDefaultValue()
    {
        _pathFolder = "Knife/Items/";
    }
}