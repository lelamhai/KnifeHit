public class HoldersShop : BaseHolders
{
    public void BuyItem(int id)
    {
        var item = transform.GetChild(id).GetComponent<ItemKnifeUI>();
    }

    protected override void SetDefaultValue()
    {}
}