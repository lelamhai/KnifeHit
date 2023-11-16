public class ReceiveDamageApple : BaseReceiveDamage
{
    protected override void DeadGameObject()
    {
        SpawnEffect.Instance.SpawnTypeEffect(TypeEffect.Apple);
        PriceManager.Instance.AddPrice(1);
        Destroy(this.transform.gameObject);
    }

    protected override void SetDefaultValue()
    {}
}