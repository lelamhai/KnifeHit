using UnityEngine;
using TMPro;
using System;

public class PriceUI : BaseMonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        UpdatePriceUI(PriceManager.Instance.Price);
        PriceManager.Instance._UpdatePriceUI += UpdatePriceUI;
    }

    private void OnDisable()
    {
        PriceManager.Instance._UpdatePriceUI -= UpdatePriceUI;
    }

    private void UpdatePriceUI(double price)
    {
        _text.text = price.ToString();
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