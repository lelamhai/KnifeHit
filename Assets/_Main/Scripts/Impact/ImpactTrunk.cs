using UnityEngine;

public class ImpactTrunk : BaseImpact
{
    [SerializeField] private HitTrunk _hitWheel;
    [SerializeField] private AnimatorWheel _animatorWheel; 

    protected override void HitGameObject(Collision2D collision)
    {
        collision.transform.SetParent(this.transform);
        SpawnEffect.Instance.SpawnTypeEffect(TypeEffect.Wood);

        _hitWheel.PlaySoundHit();
        _animatorWheel.HitWheel();
    }

    protected override void SetDefaultValue()
    {
        base.SetDefaultValue();
        _hitWheel = this.GetComponent<HitTrunk>();
    }
}