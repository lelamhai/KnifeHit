using UnityEngine;

public class Const
{
    public class Path
    {
        public readonly static string PROJECT_FOLDER = System.IO.Path.Combine(Application.dataPath, "../"); // remove assets
        public readonly static string PATH_SCRIPTOBJECT = "Assets/_Main/ScriptableObject/";
        public readonly static string PATH_PREFABS = "Assets/_Main/Prefabs/";
    }

    public class Spawn
    {
        public readonly static string HOLDERS = "Holders";
    }

    public class Prefix
    {
        public readonly static string PREFABS = ".prefab";
        public readonly static string ASSETS = ".asset";
    }
}