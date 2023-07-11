using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpUI : BaseMonoBehaviour
{
    [SerializeField] private TMP_Text _textLevel;

    //public void Show()
    //{
    //    this.gameObject.SetActive(true);
    //    SetLevel();
    //}

    //private void SetLevel()
    //{
    //    _textLevel.text = "Level: " + LevelManager.Instance.GetLevel();
    //}

    //public void Hide()
    //{
    //    this.gameObject.SetActive(false);
    //    NextLevel();
    //}

    public void NextLevel()
    {
        GameManager.Instance.SetState(GameStates.ResetGame);
        UIManager.Instance.SetPanelState(TypePanelUI.GamePlay, this.gameObject);
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        _textLevel = this.transform.Find("Level").GetComponent<TMP_Text>();
    }
}
