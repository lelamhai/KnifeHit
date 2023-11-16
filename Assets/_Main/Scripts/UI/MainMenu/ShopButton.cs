using UnityEngine;

public class ShopButton : BaseButton
{
    protected override void OnClickButton()
    {
        UIManager.Instance.SetPanelState(UIManager.Instance.CurrentPanelName, StatePanel.Hide);
        UIManager.Instance.SetPanelState(PanelName.Shop, StatePanel.Show);
    }
}