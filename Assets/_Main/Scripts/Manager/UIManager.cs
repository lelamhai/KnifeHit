using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypePanelUI
{
    GamePlay,
    MainMenu,
    ToturialGame,
    GameOver,
    SettingGame,
    PauseGame,
    LevelUp,
    FinishGame,
    QuitGame
}

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject _gamePlay;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _pauseGame;
    [SerializeField] private GameObject _settingGame;
    [SerializeField] private GameObject _levelUp;
    [SerializeField] private GameObject _finishGame;
    [SerializeField] private TypePanelUI _currentUIStage = TypePanelUI.MainMenu;

    private void Start()
    {
        SetPanelState(_currentUIStage, null);
    }

    private void UpdatePanelStage(GameObject oldPanel = null)
    {
        switch (_currentUIStage)
        {
            case TypePanelUI.GamePlay:
                _gamePlay.SetActive(true);
                break;

            case TypePanelUI.MainMenu:
                _mainMenu.SetActive(true);
                break;

            case TypePanelUI.SettingGame:
                _settingGame.SetActive(true);
                break;

            case TypePanelUI.GameOver:
                _gameOver.SetActive(true);
                break;

            case TypePanelUI.PauseGame:
                _pauseGame.SetActive(true);
                break;

            case TypePanelUI.LevelUp:
                _levelUp.SetActive(true);
                break;

            case TypePanelUI.FinishGame:
                _finishGame.SetActive(true);
                break;
        }

        if (oldPanel == null) return;
        oldPanel.SetActive(false);
    }

    public void SetPanelState(TypePanelUI state, GameObject oldPanel = null)
    {
        _currentUIStage = state;
        UpdatePanelStage(oldPanel);
    }


    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAllPanel();
    }

    private void LoadAllPanel()
    {
        _gamePlay = this.transform.Find("GamePlay").gameObject;
        _gamePlay.SetActive(true);
        _mainMenu = this.transform.Find("MainMenu").gameObject;
        _mainMenu.SetActive(false);
        _gameOver = this.transform.Find("GameOver").gameObject;
        _gameOver.SetActive(false);
        _pauseGame = this.transform.Find("PauseGame").gameObject;
        _pauseGame.SetActive(false);
        _settingGame = this.transform.Find("SettingGame").gameObject;
        _settingGame.SetActive(false);
        _levelUp = this.transform.Find("LevelUp").gameObject;
        _levelUp.SetActive(false);
        _finishGame = this.transform.Find("FinishGame").gameObject;
        _finishGame.SetActive(false);
    }
}
