using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
        StartGame();
    }

    private void StartGame()
    {
        GameManager.Instance.SetStage(GameStates.StartGame);
    }
}
