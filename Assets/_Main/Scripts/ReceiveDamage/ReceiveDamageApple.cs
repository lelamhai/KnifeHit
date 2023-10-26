using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamageApple : BaseReceiveDamage
{
    protected override void DeadGameObject()
    {
        //SpawnFXApple.Instance.SpawnGameObject("FXApple", transform.position);
        //Destroy(gameObject);
    }

    protected override void SetDefaultValue()
    {}
}
