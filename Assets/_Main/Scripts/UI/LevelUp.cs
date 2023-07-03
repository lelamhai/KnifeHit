using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public void Show()
    {
        this.gameObject.SetActive(true);
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
}
