using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameState _currentState = GameState.None;

    public UnityAction _StartGame, _GameOver, _ResetGame, _FinishLevel, _NextLevelUp, _FinishGame;
    public UnityAction<int> _SetupLevel;

    private void UpdateGameStates()
    {
        switch (_currentState)
        {
            case GameState.StartGame:
                _StartGame?.Invoke();
                break;

            case GameState.GamePlay:

                break;

            case GameState.GameOver:
                _GameOver?.Invoke();
                break;

            case GameState.FinishLevel:
                _FinishLevel?.Invoke();
                break;

            case GameState.NextLevelUp:
                _NextLevelUp?.Invoke();
                break;

            case GameState.FinishGame:
                _FinishGame?.Invoke();
                break;

            case GameState.ResetGame:
                _ResetGame?.Invoke();
                break;
        }
    }

    public void SetState(GameState state)
    {
        _currentState = state;
        UpdateGameStates();
    }

    public void SetupLevel(int count)
    {
        _SetupLevel?.Invoke(count);
    }

    protected override void SetDefaultValue()
    {}
}

public enum GameState
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