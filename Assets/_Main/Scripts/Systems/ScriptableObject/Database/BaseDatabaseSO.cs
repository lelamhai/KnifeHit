using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public abstract class BaseDatabaseSO : ScriptableObject
{
    public GenericDictionary<int, Transform> _dictionaryGameObject = new GenericDictionary<int, Transform>();

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
        _path = Path.Combine(Const.Path.PROJECT_FOLDER, Const.Path.PATH_PREFABS, _pathFolder);
        _pathAsset = Path.Combine(Const.Path.PATH_PREFABS, _pathFolder);
        var info = new DirectoryInfo(_path);
        var fileInfo = info.GetFiles("*" + Const.Prefix.PREFABS, SearchOption.AllDirectories);

        for (int i = 0; i < fileInfo.Length; i++)
        {
            //Transform gameObject = (Transform)AssetDatabase.LoadAssetAtPath("Assets/_Main/Prefabs/Knifes/" + fileInfo[i].Name, typeof(Transform));
            //BaseAttribute gameObject = (BaseAttribute)AssetDatabase.LoadAssetAtPath(_pathAsset + fileInfo[i].Name, typeof(BaseAttribute));
            BaseAttribute gameObject = (BaseAttribute)AssetDatabase.LoadAssetAtPath(_pathAsset + fileInfo[i].Name, typeof(BaseAttribute));
            if (gameObject == null)
            {
                Debug.Log("Get attribute null", this);
                return;
            }
            gameObject._Attribute._BaseAttributeSO.id = i;
            _dictionaryGameObject.Add(i, gameObject.transform);
        }
#endif
    }
}