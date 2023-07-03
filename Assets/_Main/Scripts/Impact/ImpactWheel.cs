using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactWheel : BaseImpact
{
    [SerializeField] private HitWheel _hitWheel;

    protected override void HitGameObject(Collision2D collision)
    {
        collision.transform.SetParent(this.transform);
        _hitWheel.PlaySoundHit();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();

        _hitWheel = this.GetComponent<HitWheel>();
    }
}
