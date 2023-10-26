using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : BaseMonoBehaviour
{
    [SerializeField] private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(OnClickButton);
    }

    protected abstract void OnClickButton();

    protected override void SetDefaultValue()
    {
        LoadButton();
    }

    private void LoadButton()
    {
        _button = this.transform.GetComponent<Button>();
    }
}