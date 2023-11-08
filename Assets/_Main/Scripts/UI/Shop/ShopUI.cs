using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopUI : Singleton<ShopUI>
{
    [SerializeField] private KnifesDatabase _database;
    [SerializeField] private Image _imagePickedKnife;

    public UnityAction<KnifesDatabase> _LoadDatabase;

    public UnityAction<bool> _ItemUnlock;
    public UnityAction<int, int> _ItemUse;
    public UnityAction<int, int> _ItemPicked;

    public UnityAction<int> _SuccessPicked;
    public UnityAction<int> _SuccessBuy;

    private int _currentPicked = -1;
    private int _currentUse = -1;

    private void Start()
    {
        SpawnKnife();
    }

    private void SpawnKnife()
    {
        _LoadDatabase?.Invoke(_database);
    }

    public void LoadItemUse(int id)
    {
        if (_database._Database.ContainsKey(id))
        {
            _imagePickedKnife.sprite = _database._Database[id].Model.Avatar;
            _currentUse = id;
            _currentPicked = id;
        }
    }

    public void PickedItem(int id)
    {
        if (_database._Database.ContainsKey(id))
        {
            _imagePickedKnife.sprite = _database._Database[id].Model.Avatar;
            _ItemUnlock?.Invoke(_database._Database[id].Model.Unlock);
            _ItemPicked?.Invoke(_currentPicked, id);

            _currentPicked = id;
        }
    }

    public void BuyItem()
    {
        if (_database._Database.ContainsKey(_currentPicked))
        {
            bool result = PriceManager.Instance.BuyItem(_database._Database[_currentPicked].Model.Price);
            if(result)
            {
                _SuccessBuy?.Invoke(_currentPicked);
                _ItemUnlock?.Invoke(_database._Database[_currentPicked].Model.Unlock);
            }
        }
    }

    public void UseItem()
    {
        if (_database._Database.ContainsKey(_currentPicked))
        {
            _ItemUse?.Invoke(_currentUse, _currentPicked);
            _currentUse = _currentPicked;
        }
    }

    protected override void SetDefaultValue()
    {}
}