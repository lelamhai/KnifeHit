using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [Header("Load level in GamePlay")]
    [SerializeField] private Transform parent;

    [Header("All level in Game")]
    [SerializeField] private List<GameObject> _allLevel = new List<GameObject>();


    protected override void SetDefaultValue()
    {}
}
