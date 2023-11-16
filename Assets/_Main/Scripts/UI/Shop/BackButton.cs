using UnityEngine;

public class BackButton : BaseButton
{
    [SerializeField] private PanelName _nextPanel;
    [SerializeField] private PanelName _currentPanel;

    protected override void OnClickButton()
    {
        UIManager.Instance.SetPanelState(UIManager.Instance.CurrentPanelName, StatePanel.Hide);
        UIManager.Instance.SetPanelState(_nextPanel, StatePanel.Show);
    }
}