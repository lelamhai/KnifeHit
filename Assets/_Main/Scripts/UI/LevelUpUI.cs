using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpUI : BaseMonoBehaviour
{
    [SerializeField] private TMP_Text _textLevel;

    public void Show()
    {
        this.gameObject.SetActive(true);
        SetLevel();
    }

    private void SetLevel()
    {
        _textLevel.text = "Level: " + LevelManager.Instance.GetLevel();
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
        NextLevel();
    }

    private void NextLevel()
    {
        GameManager.Instance.SetStage(GameStates.ResetGame);
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        _textLevel = this.transform.Find("Level").GetComponent<TMP_Text>();
    }
}
