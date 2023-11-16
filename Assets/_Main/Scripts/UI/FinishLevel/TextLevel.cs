using TMPro;
using UnityEngine;

public class TextLevel : BaseMonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _text.text = "Level " + LevelManager.Instance.Level.ToString();
    }

    protected override void SetDefaultValue()
    {
        _text = GetComponent<TMP_Text>();
    }
}
