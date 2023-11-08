using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUse : BaseButton
{
    private void OnEnable()
    {
        ShopUI.Instance._ItemUnlock += PickItem;
    }

    private void OnDisable()
    {
        ShopUI.Instance._ItemUnlock -= PickItem;
    }

    private void PickItem(bool active)
    {
        _button.interactable = active;
    }

    protected override void OnClickButton()
    {
        ShopUI.Instance.UseItem();
    }
}
