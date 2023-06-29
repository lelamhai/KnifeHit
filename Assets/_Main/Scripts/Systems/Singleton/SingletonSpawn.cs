using UnityEngine;

public abstract class SingletonSpawn<T> : BaseSpawn where T : SingletonSpawn<T>
{
    static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null) _instance = (T)FindObjectOfType(typeof(T));
            if (_instance == null) Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
            return _instance;
        }
    }

    protected void Awake()
    {
        if (_instance == null) _instance = this as T;
        else if (_instance != this) Destroy(this);
    }
}