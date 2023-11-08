using UnityEngine;
using TMPro;
using System;

public class PriceUI : BaseMonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        PriceManager.Instance._UpdatePriceUI += UpdatePriceUI;
        ShowPrice();
    }

    private void OnDisable()
    {
        PriceManager.Instance._UpdatePriceUI -= UpdatePriceUI;
    }

    private void UpdatePriceUI(int price)
    {
        _text.text = price.ToString();
    }

    private void ShowPrice()
    {
        PriceManager.Instance.UpdatePriceUI();
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