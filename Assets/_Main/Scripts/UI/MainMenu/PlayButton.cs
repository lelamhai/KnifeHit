public class PlayButton : BaseButton
{
    protected override void OnClickButton()
    {
        GameManager.Instance.SetState(GameState.StartGame);
        UIManager.Instance.SetPanelState(PanelName.MainMenu, StatePanel.Hide);
        UIManager.Instance.SetPanelState(PanelName.GamePlay, StatePanel.Show);
    }
}