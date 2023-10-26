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
        GameManager.Instance.SetState(GameState.ResetGame);
        //UIManager.Instance.SetPanelState(PanelName.GamePlay, this.gameObject);
    }

    protected override void SetDefaultValue()
    {
        _textLevel = this.transform.Find("Level").GetComponent<TMP_Text>();
    }
}
