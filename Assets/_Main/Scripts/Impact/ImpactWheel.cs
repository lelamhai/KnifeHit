using UnityEngine;

public class ImpactWheel : BaseImpact
{
    [SerializeField] private HitWheel _hitWheel;

    protected override void HitGameObject(Collision2D collision)
    {
        collision.transform.SetParent(this.transform);
        _hitWheel.PlaySoundHit();
    }

    protected override void SetDefaultValue()
    {
        base.SetDefaultValue();
        _hitWheel = this.GetComponent<HitWheel>();
    }
}