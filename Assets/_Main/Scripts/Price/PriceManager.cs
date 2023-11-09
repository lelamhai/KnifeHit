using UnityEngine;
using UnityEngine.Events;

public class PriceManager : Singleton<PriceManager>, IDataPersistence
{
    [SerializeField] private PriceDatabase _priceData;

    public UnityAction<double> _UpdatePriceUI;

    private void Start()
    {
        RegisterData();

    }

    public bool BuyItem(int price)
    {
        if (_priceData._Price < 0) return false;
        if (_priceData._Price < price) return false;

        _priceData._Price -= price;
        UpdatePriceUI();
        return true;
    }

    public void UpdatePriceUI()
    {
        _UpdatePriceUI?.Invoke(_priceData._Price);
    }

    protected override void SetDefaultValue()
    {}

    public void LoadData(GameData data)
    {
        _priceData._Price = data.Price;
    }

    public void SaveData(GameData data)
    {
        data.Price = _priceData._Price;
    }

    public void RegisterData()
    {
        DataPersistanceManager.Instance.RegisterEventDataPersistance(this);
    }
}