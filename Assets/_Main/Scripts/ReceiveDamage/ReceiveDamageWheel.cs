using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamageWheel : BaseReceiveDamage
{
    [SerializeField] private DeadWheel _deadWheel;


    private void OnEnable()
    {
        GameManager.Instance._SetupLevel += SetupLevel;
        _currentHealth = _maxHealth;
    }

    private void OnDisable()
    {
        GameManager.Instance._SetupLevel += SetupLevel;
    }

    private void SetupLevel(int count)
    {
        _maxHealth = count;
    }
  
    protected override void DeadGameObject()
    {
        _deadWheel.PlaySoundDead();
        GameManager.Instance.SetState(GameState.FinishLevel);
        Destroy(gameObject);
    }

    protected override void SetDefaultValue()
    {
        _deadWheel = this.GetComponent<DeadWheel>();
    }
}