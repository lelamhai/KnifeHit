using UnityEngine;

public class ImpactWheel : BaseImpact
{
    [SerializeField] private HitWheel _hitWheel;
    [SerializeField] private AnimatorWheel _animatorWheel; 

    protected override void HitGameObject(Collision2D collision)
    {
        collision.transform.SetParent(this.transform);
        SpawnEffect.Instance.SpawnGameObject(TypeEffect.Wood);

        _hitWheel.PlaySoundHit();
        _animatorWheel.HitWheel();
    }

    protected override void SetDefaultValue()
    {
        base.SetDefaultValue();
        _hitWheel = this.GetComponent<HitWheel>();
    }
}