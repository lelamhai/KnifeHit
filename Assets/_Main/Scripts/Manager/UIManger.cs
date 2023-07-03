using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : Singleton<UIManger>
{
    [SerializeField] private GamePlay _gamePlay;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private PauseGame _pauseGame;
    [SerializeField] private SettingGame _settingGame;
    [SerializeField] private LevelUp _levelUp;
    [SerializeField] private FinishGame _finishGame;

    private void OnEnable()
    {
        GameManager.Instance._EndGame += ShowGameOver;
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
        GameManager.Instance._EndGame -= ShowGameOver;
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
        _gamePlay = this.transform.Find("GamePlay").GetComponent<GamePlay>();
        _mainMenu = this.transform.Find("MainMenu").GetComponent<MainMenu>();
        _gameOver = this.transform.Find("GameOver").GetComponent<GameOver>();
        _pauseGame = this.transform.Find("PauseGame").GetComponent<PauseGame>();
        _settingGame = this.transform.Find("SettingGame").GetComponent<SettingGame>();
        _levelUp = this.transform.Find("LevelUp").GetComponent<LevelUp>();
        _finishGame = this.transform.Find("FinishGame").GetComponent<FinishGame>();
    }
}
