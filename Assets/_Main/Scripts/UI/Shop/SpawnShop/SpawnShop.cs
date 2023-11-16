using System.Collections.Generic;
using UnityEngine;

public class SpawnShop : BaseMonoBehaviour
{
    [SerializeField] private Transform _prefab;
    [SerializeField] private Transform _holders;
    [SerializeField] private GenericDictionary<int, Transform> _holdersObject = new GenericDictionary<int, Transform>();

    private void OnEnable()
    {
        ShopUI.Instance._LoadDatabase += LoadItemInShop;
        ShopUI.Instance._SuccessBuy += SuccessBuy;
        ShopUI.Instance._ItemUse += ItemUse;
        ShopUI.Instance._ItemPicked += ItemPicked;
    }

    private void OnDisable()
    {
        ShopUI.Instance._LoadDatabase -= LoadItemInShop;
        ShopUI.Instance._SuccessBuy -= SuccessBuy;
        ShopUI.Instance._ItemUse -= ItemUse;
        ShopUI.Instance._ItemPicked -= ItemPicked;
    }

    private void ItemUse(int oldId, int newId)
    {
        if (_holdersObject.ContainsKey(oldId))
        {
            Transform oldItem = _holdersObject[oldId];
            ItemKnifeUI oldItemUI = oldItem.GetComponent<ItemKnifeUI>();
            oldItemUI.SetUse(false);
            oldItemUI._ItemData.Model.Use = false;
        }

        if (_holdersObject.ContainsKey(newId))
        {
            Transform newItem = _holdersObject[newId];
            ItemKnifeUI newItemUI = newItem.GetComponent<ItemKnifeUI>();
            newItemUI.SetUse(true);
            newItemUI._ItemData.Model.Use = true;
        }
    }

    private void ItemPicked(int oldId, int newId)
    {
        if(_holdersObject.ContainsKey(oldId))
        {
            Transform oldItem = _holdersObject[oldId];
            ItemKnifeUI oldItemUI = oldItem.GetComponent<ItemKnifeUI>();
            oldItemUI.SetFrame(false);
        }

        if(_holdersObject.ContainsKey(newId))
        {
            Transform newItem = _holdersObject[newId];
            ItemKnifeUI newItemUI = newItem.GetComponent<ItemKnifeUI>();
            newItemUI.SetFrame(true);
        }
    }

    private void SuccessBuy(int id)
    {
        if (_holdersObject.ContainsKey(id))
        {
            Transform item = _holdersObject[id];
            if (item == null) return;

            ItemKnifeUI itemUI = item.GetComponent<ItemKnifeUI>();
            itemUI.SetWrapApple(true);
            itemUI._ItemData.Model.Unlock = true;
        }
    }

    private void LoadItemInShop(KnifesDatabase data)
    {
        foreach (KeyValuePair<int, ItemKnifeDatabase> item in data.Database)
        {
            var clone = Instantiate(_prefab);
            _holdersObject.Add(item.Key, clone);
            clone.SetParent(_holders);
            clone.localScale = Vector3.one;
            var knifeUI = clone.GetComponent<ItemKnifeUI>();
            if (knifeUI == null) return;

            knifeUI.LoadData(item.Value);
            knifeUI.UpdateInfo(item.Value.Model);
            if (item.Value.Model.Use)
            {
                knifeUI.SetUse(true);
                knifeUI.SetFrame(true);
                ShopUI.Instance.LoadItemUse(item.Key);
            }
        }
    }

    protected override void SetDefaultValue()
    {}
}