using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRestart : BaseButton
{
    protected override void OnClickButton()
    {
        GameManager.Instance.SetState(GameState.Initialize);
        UIManager.Instance.SetPanelState(UIManager.Instance.CurrentPanelName, StatePanel.Hide);
        UIManager.Instance.SetPanelState(PanelName.GamePlay, StatePanel.Show);
    }
}
