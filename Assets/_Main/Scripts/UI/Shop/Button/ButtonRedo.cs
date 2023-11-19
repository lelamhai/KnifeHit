public class ButtonRedo : BaseButton
{
    protected override void OnClickButton()
    {
        UIManager.Instance.SetPanelState(UIManager.Instance.CurrentPanelName, StatePanel.Hide);
        UIManager.Instance.Load();
        UIManager.Instance.SetPanelState(UIManager.Instance.CurrentPanelName, StatePanel.Show);
    }
}