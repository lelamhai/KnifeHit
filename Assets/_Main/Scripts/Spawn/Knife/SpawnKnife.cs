using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeKnife
{
    Knife0,
    Knife1
}

public class SpawnKnife : SingletonSpawn<SpawnKnife>
{
    [SerializeField] private bool _isShooting = false;
    [SerializeField] private TypeKnife _currentKnife = TypeKnife.Knife0;

    private void OnEnable()
    {
        GameManager.Instance._StartGame += StartGame;
        GameManager.Instance._SetupLevel += SetupLevel;
        GameManager.Instance._EndGame += EndGame;
        GameManager.Instance._NextLevelUp += EndGame;
        GameManager.Instance._FinishGame += EndGame;
    }

    private void OnDisable()
    {
        GameManager.Instance._StartGame -= StartGame;
        GameManager.Instance._SetupLevel -= SetupLevel;
        GameManager.Instance._EndGame -= EndGame;
        GameManager.Instance._NextLevelUp -= EndGame;
        GameManager.Instance._FinishGame -= EndGame;
    }

    private void SetupLevel(int count)
    {
        StartGame();
        Clear();
        Initial(count);
    }


    private void StartGame()
    {
        _isShooting = true;
    }

    private void EndGame()
    {
        _isShooting = false;
    }

    private void Clear()
    {
        _isShooting = true;
        _baseHolders.ResetGame();
    }

    private void Initial(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Transform knife = SpawnGameObjectReturn(_currentKnife.ToString(), _point.position);
            knife.gameObject.SetActive(true);
        }
    }

    public void Shooting()
    {
        if (!_isShooting) return;

        var move = _baseHolders.transform.GetChild(0).GetComponent<MoveKnife>();
        move.enabled = true;

        var box = _baseHolders.transform.GetChild(0).GetComponent<BoxCollider2D>();
        box.enabled = true;

        UIManger.Instance.Shooting();
    }
    protected override void SetDefaultValue()
    {}
}
