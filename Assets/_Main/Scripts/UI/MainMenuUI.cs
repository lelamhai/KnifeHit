using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.SetState(GameState.StartGame);
        //UIManager.Instance.SetPanelState(PanelName.GamePlay, this.gameObject);
    }
}
