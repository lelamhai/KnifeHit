using UnityEngine;

public class OpenShopButton : BaseButton
{
    protected override void OnClickButton()
    {
        UIManager.Instance.Save();
        UIManager.Instance.SetPanelState(UIManager.Instance.CurrentPanelName, StatePanel.Hide);
        UIManager.Instance.SetPanelState(PanelName.Shop, StatePanel.Show);
    }
}