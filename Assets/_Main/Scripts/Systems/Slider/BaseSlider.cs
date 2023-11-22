using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : BaseMonoBehaviour
{
    [SerializeField] protected Slider _slider;
    protected virtual void Start()
    {
        _slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    public abstract void ValueChangeCheck();

    protected override void SetDefaultValue()
    {
        LoadSlider();
    }

    private void LoadSlider()
    {
        _slider = this.GetComponent<Slider>();
    }
}
