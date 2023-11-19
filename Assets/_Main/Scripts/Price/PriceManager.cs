using UnityEngine;
using UnityEngine.Events;

public class PriceManager : Singleton<PriceManager>, IDataPersistence
{
    [SerializeField] private PriceDatabase _data;

    public double Price
    {
        get => _data.Price;
    }

    public UnityAction<double> _UpdatePriceUI;

    private void Awake()
    {
        RegisterData();
    }

    private void OnEnable()
    {
        UpdatePriceUI();
    }

    public bool BuyItem(int price)
    {
        if (_data.Price < 0) return false;
        if (_data.Price < price) return false;

        _data.Price -= price;
        UpdatePriceUI();
        return true;
    }

    public void AddPrice(int price)
    {
        _data.Price += price;
        UpdatePriceUI();
    }

    private void UpdatePriceUI()
    {
        _UpdatePriceUI?.Invoke(_data.Price);
    }

    protected override void SetDefaultValue()
    {}

    public void LoadData(GameData data)
    {
        _data.Price = data.Price;
    }

    public void SaveData(GameData data)
    {
        data.Price = _data.Price;
    }

    public void RegisterData()
    {
        DataPersistanceManager.Instance.RegisterEventDataPersistance(this);
    }
}