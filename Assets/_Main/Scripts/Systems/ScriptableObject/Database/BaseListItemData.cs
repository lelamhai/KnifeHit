using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public abstract class BaseListItemData : ScriptableObject
{
    public GenericDictionary<int, BaseItemDataSO> _ListItemData = new GenericDictionary<int, BaseItemDataSO>();

    [SerializeField] protected string _pathFolder = string.Empty;
    protected string _path = string.Empty;
    protected string _pathAsset = string.Empty;

    private void Reset()
    {
        SetDefaultValue();
        LoadComponent();
    }

    protected void LoadComponent()
    {
        LoadScriptableObject();
    }

    protected abstract void SetDefaultValue();

    private void LoadScriptableObject()
    {
#if UNITY_EDITOR
        _path = Path.Combine(Const.Path.PROJECT_FOLDER, Const.Path.PATH_SCRIPTOBJECT, _pathFolder);
        _pathAsset = Path.Combine(Const.Path.PATH_SCRIPTOBJECT, _pathFolder);
        var info = new DirectoryInfo(_path);
        var fileInfo = info.GetFiles("*" + Const.Prefix.ASSETS, SearchOption.AllDirectories);

        for (int i = 0; i < fileInfo.Length; i++)
        {
            BaseItemDataSO gameObject = (BaseItemDataSO)AssetDatabase.LoadAssetAtPath(_pathAsset + fileInfo[i].Name, typeof(BaseItemDataSO));
            if (gameObject == null)
            {
                Debug.Log("Get ItemDataSO null", this);
                return;
            }
            gameObject._itemInfo.id = i;
            _ListItemData.Add(i, gameObject);
        }
#endif
    }
}