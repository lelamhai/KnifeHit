public class ButtonPlay : BaseButton
{
    protected override void OnClickButton()
    {
        GameManager.Instance.SetState(GameState.Initialize);
        UIManager.Instance.SetPanelState(PanelName.MainMenu, StatePanel.Hide);
        UIManager.Instance.SetPanelState(PanelName.GamePlay, StatePanel.Show);
    }
}