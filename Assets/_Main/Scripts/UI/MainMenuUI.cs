using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.SetState(GameStates.StartGame);
        UIManager.Instance.SetPanelState(TypePanelUI.GamePlay, this.gameObject);
    }
}
