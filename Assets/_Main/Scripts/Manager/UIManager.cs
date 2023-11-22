using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private List<GameObject> _listPanel = new List<GameObject>();
    [SerializeField] private PanelName _currentPanelName = PanelName.None;

    private Stack<int> _storgePanel = new Stack<int>();

    public PanelName CurrentPanelName
    {
        get => _currentPanelName;
    }

    private void Awake()
    {
        SetPanelState(PanelName.MainMenu, StatePanel.Show);
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

    public void clear()
    {
        _storgePanel.Clear();
    }

    public void Save()
    {
        _storgePanel.Push((int)_currentPanelName);
    }

    public void Load()
    {
        _currentPanelName = (PanelName)_storgePanel.Pop();
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
    None = 0,
    MainMenu = 1,
    GamePlay = 2,
    Shop = 3,
    GameOver = 4,
    FinishLevel = 5,
    Setting
}

public enum StatePanel
{
    Show,
    Hide
}