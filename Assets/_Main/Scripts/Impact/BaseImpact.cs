using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseImpact : BaseMonoBehaviour
{
    [SerializeField] protected BaseDamage _baseDamage = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BaseReceiveDamage receiveDamage = collision.transform.GetComponent<BaseReceiveDamage>();
        if (receiveDamage == null) return;
        receiveDamage.TakeDamage(_baseDamage.Damage());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BaseReceiveDamage receiveDamage = collision.transform.GetComponent<BaseReceiveDamage>();
        if (receiveDamage == null) return;
        receiveDamage.TakeDamage(_baseDamage.Damage());
        HitGameObject(collision);
    }

    protected abstract void HitGameObject(Collision2D collision);

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        _baseDamage = this.GetComponent<BaseDamage>();
    }
}
