using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrunk : Singleton<SpawnTrunk>
{
    [SerializeField] private TrunkDatabase _data;
    [SerializeField] private TypeTrunk _currentTrunk = TypeTrunk.None;

    public void RemoveTrunk()
    {
        Destroy(transform.GetChild(0).gameObject);
    }

    public void LoadTrunk(TypeTrunk typeTrunk)
    {
        _currentTrunk = typeTrunk;
        CloneTrunk(_data.Database[(int)_currentTrunk].Model.Prefab);
        GameManager.Instance.SetupLevel(_data.Database[(int)_currentTrunk].Model.Health);
    }

    public void LoadTrunk(int trunk)
    {
        _currentTrunk = (TypeTrunk)trunk;
        CloneTrunk(_data.Database[(int)_currentTrunk].Model.Prefab);
    }

    private void CloneTrunk(Transform prefab)
    {
        var clone = Instantiate(prefab);
        clone.SetParent(this.transform);
    }

    protected override void SetDefaultValue()
    {}
}

public enum TypeTrunk
{
    None = -1,
    Trunk_00 = 0
}