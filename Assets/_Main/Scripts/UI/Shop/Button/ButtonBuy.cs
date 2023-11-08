using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBuy : BaseButton
{
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
        ShopUI.Instance.BuyItem();
    }
}
