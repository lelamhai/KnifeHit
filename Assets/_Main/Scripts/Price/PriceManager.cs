using UnityEngine;
using UnityEngine.Events;

public class PriceManager : Singleton<PriceManager>
{
    [SerializeField] private int _price = 0;

    public UnityAction<int> _UpdatePriceUI;
    public int _Price
    {
        get => _price;
    }

    public bool BuyItem(int price)
    {
        if (_price < 0) return false;
        if (_price < price) return false;

        _price -= price;
        UpdatePriceUI();
        return true;
    }

    public void UpdatePriceUI()
    {
        _UpdatePriceUI?.Invoke(_price);
    }

    protected override void SetDefaultValue()
    {}
}