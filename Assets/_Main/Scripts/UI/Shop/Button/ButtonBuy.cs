using UnityEngine;

public class ButtonBuy : BaseButton
{
    [SerializeField] private AudioClip _buyItem;
    private void OnEnable()
    {
        ShopUI.Instance._ItemUnlock += BuyItem;
    }

    private void OnDisable()
    {
        ShopUI.Instance._ItemUnlock -= BuyItem;
    }

    private void BuyItem(bool active)
    {
        _button.interactable = !active;
    }

    protected override void OnClickButton()
    {
        ShopUI.Instance.BuyItem(()=> {
            AudioManager.Instance.PlaySound(_buyItem);
            DataPersistanceManager.Instance.SaveData();
        });
    }
}
