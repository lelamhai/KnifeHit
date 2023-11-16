public class ButtonNext : BaseButton
{
    protected override void OnClickButton()
    {
        GameManager.Instance.SetState(GameState.Initialize);
        UIManager.Instance.SetPanelState(PanelName.FinishLevel, StatePanel.Hide);
        UIManager.Instance.SetPanelState(PanelName.GamePlay, StatePanel.Show);
    }
}