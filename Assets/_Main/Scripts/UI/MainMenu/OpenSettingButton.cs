public class OpenSettingButton : BaseButton
{
    protected override void OnClickButton()
    {
        UIManager.Instance.Save();
        UIManager.Instance.SetPanelState(UIManager.Instance.CurrentPanelName, StatePanel.Hide);
        UIManager.Instance.SetPanelState(PanelName.Setting, StatePanel.Show);
    }
}