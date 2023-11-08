public class ShopButton : BaseButton
{
    protected override void OnClickButton()
    {
        UIManager.Instance.SetPanelState(PanelName.MainMenu, StatePanel.Hide);
        UIManager.Instance.SetPanelState(PanelName.Shop, StatePanel.Show);
    }
}