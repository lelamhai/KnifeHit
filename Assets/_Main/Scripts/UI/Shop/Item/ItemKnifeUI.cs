using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemKnifeUI : BaseMonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image _avatar;
    [SerializeField] private Transform _wrapApple;
    [SerializeField] private TMP_Text _textPrice;
    [SerializeField] private Transform _use;
    [SerializeField] private Transform _frame;
    [SerializeField] private AudioClip _sound;

    [Header("Database")]
    [SerializeField] private ItemKnifeDatabase _itemData;
    public ItemKnifeDatabase _ItemData
    {
        get => _itemData;
    }

    public void LoadData(ItemKnifeDatabase item)
    {
        _itemData = item;
    }

    public void UpdateInfo(KnifeModel model)
    {
        _avatar.sprite = model.Avatar;
        _textPrice.text = model.Price.ToString();
        SetWrapApple(model.Unlock);
    }

    public void OnPickedItem()
    {
        ShopUI.Instance.PickedItem(_itemData.Model.Id);
        AudioManager.Instance.PlaySound(_sound);
    }

    public void SetWrapApple(bool active)
    {
        _wrapApple.gameObject.SetActive(!active);
    }

    public void SetUse(bool active)
    {
        _use.gameObject.SetActive(active);
    }

    public void SetFrame(bool active)
    {
        _frame.gameObject.SetActive(active);
    }

    protected override void SetDefaultValue()
    {}
}