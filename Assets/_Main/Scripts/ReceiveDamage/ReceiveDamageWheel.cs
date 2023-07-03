using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamageWheel : BaseReceiveDamage
{
    [SerializeField] private SettingWheel _settingWheel;
    [SerializeField] private DeadWheel _deadWheel;

    private void Start()
    {
        _maxHealth = _settingWheel.GetHealth();
        _currentHealth = _maxHealth;
    }

    protected override void DeadGameObject()
    {
        _deadWheel.PlaySoundDead();
        GameManager.Instance.SetStage(GameStates.FinishLevel);
        Destroy(gameObject);
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        _deadWheel = this.GetComponent<DeadWheel>();
        _settingWheel = this.GetComponent<SettingWheel>();
    }
}
