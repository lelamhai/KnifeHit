using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeKnife
{
    Knife0,
    Knife1,
    Knife2
}

public class SpawnKnife : SingletonSpawn<SpawnKnife>
{
    public void Shooting()
    {
        Transform knife = SpawnGameObjectReturn(TypeKnife.Knife0.ToString(), _point.position);
        knife.GetComponent<MoveKnife>().SetMovement();
    }
    protected override void SetDefaultValue()
    {}
}
