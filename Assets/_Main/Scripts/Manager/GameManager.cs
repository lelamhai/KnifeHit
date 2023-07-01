using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public void Shooting()
    {
        SpawnKnife.Instance.Shooting();
    }

    protected override void SetDefaultValue()
    {}
}
