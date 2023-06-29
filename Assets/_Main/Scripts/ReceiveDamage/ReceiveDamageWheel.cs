using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamageWheel : BaseReceiveDamage
{
    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    protected override void DeadGameObject()
    {

    }

    protected override void SetDefaultValue()
    {
        _maxHealth = 10;
    }
}
