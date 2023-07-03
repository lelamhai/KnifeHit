using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text _level;

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
        ResetGame();
    }

    public void SetLevel(int level)
    {
        _level.text = "Level: " + level;
    }

    private void ResetGame()
    {
        GameManager.Instance.SetStage(GameStates.ResetGame);
    }
}
