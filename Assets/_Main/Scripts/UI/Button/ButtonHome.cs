public class ButtonHome : BaseButton
{
    protected override void OnClickButton()
    {
        UIManager.Instance.SetPanelState(UIManager.Instance.CurrentPanelName, StatePanel.Hide);
        UIManager.Instance.SetPanelState(PanelName.MainMenu, StatePanel.Show);
    }
}