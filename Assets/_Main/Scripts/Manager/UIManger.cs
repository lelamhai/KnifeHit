using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : Singleton<UIManger>
{
    [SerializeField] private GamePlayUI _gamePlay;
    [SerializeField] private MainMenuUI _mainMenu;
    [SerializeField] private GameOverUI _gameOver;
    [SerializeField] private PauseGameUI _pauseGame;
    [SerializeField] private SettingGameUI _settingGame;
    [SerializeField] private LevelUpUI _levelUp;
    [SerializeField] private FinishGameUI _finishGame;

    private void OnEnable()
    {
        GameManager.Instance._GameOver += ShowGameOver;
        GameManager.Instance._SetupLevel += SetupLevel;
        GameManager.Instance._NextLevelUp += NextLevel;
        GameManager.Instance._FinishGame += Finish;
    }

    private void Finish()
    {
        _finishGame.Show();
    }

    private void OnDisable()
    {
        GameManager.Instance._GameOver -= ShowGameOver;
        GameManager.Instance._SetupLevel -= SetupLevel;
        GameManager.Instance._NextLevelUp -= NextLevel;
        GameManager.Instance._FinishGame += Finish;
    }

    private void NextLevel()
    {
        _levelUp.Show();
    }

    private void SetupLevel(int count)
    {
        _gamePlay.SpawnImageKnife(count);
    }

    private void ShowGameOver()
    {
        _gameOver.Show();
    }

    public void Shooting()
    {
        _gamePlay.HideImageKnife();
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        _gamePlay = this.transform.Find("GamePlay").GetComponent<GamePlayUI>();
        _mainMenu = this.transform.Find("MainMenu").GetComponent<MainMenuUI>();
        _gameOver = this.transform.Find("GameOver").GetComponent<GameOverUI>();
        _pauseGame = this.transform.Find("PauseGame").GetComponent<PauseGameUI>();
        _settingGame = this.transform.Find("SettingGame").GetComponent<SettingGameUI>();
        _levelUp = this.transform.Find("LevelUp").GetComponent<LevelUpUI>();
        _finishGame = this.transform.Find("FinishGame").GetComponent<FinishGameUI>();
    }
}
