using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private List<GameObject> _listPanel = new List<GameObject>();
    [SerializeField] private PanelName _currentPanelName = PanelName.MainMenu;

    private void Awake()
    {
        SetPanelState(_currentPanelName, StatePanel.Show);
    }

    public void SetPanelState(PanelName namePanel, StatePanel statePanel)
    {
        _currentPanelName = namePanel;
        switch (statePanel)
        {
            case StatePanel.Show:
                ShowPanel();
                break;

            case StatePanel.Hide:
                HidePanel();
                break;

            default:
                break;
        }
    }

    private void ShowPanel()
    {
        GameObject panel = _listPanel.Where(obj => obj.name == _currentPanelName.ToString()).SingleOrDefault();
        if (panel == null) return;
        panel.SetActive(true);
    }

    private void HidePanel()
    {
        GameObject panel = _listPanel.Where(obj => obj.name == _currentPanelName.ToString()).SingleOrDefault();
        if (panel == null) return;
        panel.SetActive(false);
    }

    protected override void SetDefaultValue()
    {
        LoadAllPanelUI();
    }

    private void LoadAllPanelUI()
    {
        Transform parent = this.transform;
        foreach (Transform item in parent)
        {
            item.gameObject.SetActive(false);
            _listPanel.Add(item.gameObject);
        }
    }
}
public enum PanelName
{
    MainMenu,
    GamePlay,
    ToturialGame,
    GameOver,
    SettingGame,
    PauseGame,
    LevelUp,
    FinishGame,
    QuitGame
}

public enum StatePanel
{
    Show,
    Hide
}