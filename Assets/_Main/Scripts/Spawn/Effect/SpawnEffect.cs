using System;
using UnityEngine;

public class SpawnEffect : Singleton<SpawnEffect>
{
    [SerializeField] private EffectsDatabase _data;
    [SerializeField] private HoldersEffect _holders;
    [SerializeField] private Transform _point;
    private TypeEffect _currentEffect;

    public void SpawnTypeEffect(TypeEffect typeEffect)
    {
        _currentEffect = typeEffect;
        CloneKnife(_data.Database[(int)_currentEffect].Model.Prefab, _point);
    }

    private void CloneKnife(Transform prefab, Transform point)
    {
        Transform effect = _holders.Get((int)_currentEffect);
        if(effect == null)
        {
            var clone = Instantiate(prefab);
            if((int)_currentEffect < 2)
            {
                clone.position = point.position;
            }
            clone.SetParent(_holders.transform);
            _holders.Add((int)_currentEffect, clone);
        }
    }

    protected override void SetDefaultValue()
    {
    }
}

public enum TypeEffect
{
    Apple = 0,
    Wood = 1,
    Shop = 2,
    Reward = 3
}