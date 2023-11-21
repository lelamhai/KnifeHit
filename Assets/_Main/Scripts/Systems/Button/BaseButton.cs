using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : BaseMonoBehaviour
{
    [SerializeField] protected Button _button;

    protected virtual void Start()
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