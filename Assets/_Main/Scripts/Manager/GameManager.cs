using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameStates
{
    None,
    StartGame, 
    GamePlay,
    ResetGame,
    FinishLevel,
    NextLevelUp,
    FinishGame,
    GameOver
}

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameStates _currentStage = GameStates.None;
    public UnityAction _StartGame, _GameOver, _ResetGame, _FinishLevel, _NextLevelUp, _FinishGame;

    public UnityAction<int> _SetupLevel;

    private void UpdateGameStates()
    {
        switch (_currentStage)
        {
            case GameStates.StartGame:
                _StartGame?.Invoke();
                break;

            case GameStates.GamePlay:

                break;

            case GameStates.GameOver:
                _GameOver?.Invoke();
                break;

            case GameStates.FinishLevel:
                _FinishLevel?.Invoke();
                break;

            case GameStates.NextLevelUp:
                _NextLevelUp?.Invoke();
                break;

            case GameStates.FinishGame:
                _FinishGame?.Invoke();
                break;

            case GameStates.ResetGame:
                _ResetGame?.Invoke();
                break;
        }
    }

    public void SetState(GameStates state)
    {
        _currentStage = state;
        UpdateGameStates();
    }

    public void SetupLevel(int count)
    {
        _SetupLevel?.Invoke(count);
    }

    protected override void SetDefaultValue()
    {}
}
