using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [Header("Load level in GamePlay")]
    [SerializeField] private Transform parent;

    [Header("All level in Game")]
    [SerializeField] private LevelDatabase _levelData;
    [SerializeField] private List<Transform> _listAllLevel = new List<Transform>();

    private Transform _currentLevelGameObject = null;

    private void OnEnable()
    {
        GameManager.Instance._StartGame += LoadLevel;
        GameManager.Instance._FinishLevel += LevelUp;
        GameManager.Instance._ResetGame += LoadLevel;
    }

    private void OnDisable()
    {
        GameManager.Instance._StartGame -= LoadLevel;
        GameManager.Instance._FinishLevel -= LevelUp;
        GameManager.Instance._ResetGame -= LoadLevel;
    }

    public int GetLevel()
    {
        return _levelData._Level;
    }

    private void LevelUp()
    {
        _levelData._Level++;
        if (_levelData._Level <= _listAllLevel.Count-1)
        {
            GameManager.Instance.SetState(GameState.NextLevelUp);
            //UIManager.Instance.SetPanelState(PanelName.LevelUp);
        } else
        {
            GameManager.Instance.SetState(GameState.FinishGame);
            //UIManager.Instance.SetPanelState(PanelName.FinishGame);
        }
    }

    private void LoadLevel()
    {
        if (_currentLevelGameObject != null)
        {
            Destroy(_currentLevelGameObject.gameObject);
        }

        if (_listAllLevel.Count <= 0)
        {
            Debug.LogError("List level empty");
            return;
        }

        _currentLevelGameObject = Instantiate(_listAllLevel[_levelData._Level], parent);
        _currentLevelGameObject.transform.SetParent(parent);
    }

    protected override void SetDefaultValue()
    {}
}