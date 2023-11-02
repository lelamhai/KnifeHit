using UnityEngine;
using TMPro;

public class PointUI : Singleton<PointUI>
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _point = 0;

    public void AddPoint(int point)
    {
        _point += point;
        _text.text = _point.ToString();
    }

    protected override void SetDefaultValue()
    {
        LoadText();
    }

    private void LoadText()
    {
        _text = this.transform.GetComponent<TMP_Text>();
    }
}