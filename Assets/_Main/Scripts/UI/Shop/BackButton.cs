public class BackButton : BaseButton
{
    protected override void OnClickButton()
    {
        UIManager.Instance.SetPanelState(PanelName.Shop, StatePanel.Hide);
        UIManager.Instance.SetPanelState(PanelName.MainMenu, StatePanel.Show);
    }
}