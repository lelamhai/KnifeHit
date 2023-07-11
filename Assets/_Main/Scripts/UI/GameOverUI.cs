using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : BaseMonoBehaviour
{
    [SerializeField] private TMP_Text _level;

    public void Show()
    {
        this.gameObject.SetActive(true);
        SetLevel();
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
        ResetGame();
    }

    private void SetLevel()
    {
        _level.text = "Level: " + LevelManager.Instance.GetLevel();
    }

    private void ResetGame()
    {
        GameManager.Instance.SetState(GameStates.ResetGame);
    }

    protected override void SetDefaultValue()
    {
        _level = this.transform.Find("Level").GetComponent<TMP_Text>();
    }
}
