using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameState _currentState = GameState.None;

    public UnityAction _Initialize, _GameOver, _FinishLevel, _ChangeKnife;
    public UnityAction<int> _SetupLevel;


    private void UpdateGameStates()
    {
        switch (_currentState)
        {
            case GameState.Initialize:
                _Initialize?.Invoke();
                break;

            case GameState.FinishLevel:
                _FinishLevel?.Invoke();
                break;

            case GameState.GameOver:
                _GameOver?.Invoke();

                StartCoroutine(IE_GameOver());
                break;

            case GameState.ChangeKnife:
                _ChangeKnife?.Invoke();
                break;

        }
    }

    private IEnumerator IE_GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        SpawnKnife.Instance.BackHolder();

        yield return new WaitForSeconds(0.2f);
        SpawnTrunk.Instance.RemoveTrunk();
        UIManager.Instance.SetPanelState(PanelName.GamePlay, StatePanel.Hide);
        UIManager.Instance.SetPanelState(PanelName.GameOver, StatePanel.Show);
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
    Initialize,
    SetupLevel,
    FinishLevel,
    GameOver,

    ChangeKnife

    //FinishLevel,
    //LevelUp
}