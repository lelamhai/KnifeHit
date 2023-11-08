using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShop : BaseSpawn
{
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
        Transform oldItem = _baseHolders.GetItemByIndex(oldId);
        if (oldItem == null) return;
        ItemKnifeUI oldItemUI = oldItem.GetComponent<ItemKnifeUI>();
        oldItemUI.SetUse(false);
        oldItemUI._ItemData.Model.Use = false;

        Transform newItem = _baseHolders.GetItemByIndex(newId);
        if (newItem == null) return;
        ItemKnifeUI newItemUI = newItem.GetComponent<ItemKnifeUI>();
        newItemUI.SetUse(true);
        newItemUI._ItemData.Model.Use = true;
    }

    private void ItemPicked(int oldId, int newId)
    {
        Transform oldItem = _baseHolders.GetItemByIndex(oldId);
        if (oldItem == null) return;
        ItemKnifeUI oldItemUI = oldItem.GetComponent<ItemKnifeUI>();
        oldItemUI.SetFrame(false);

        Transform newItem = _baseHolders.GetItemByIndex(newId);
        if (newItem == null) return;
        ItemKnifeUI newItemUI = newItem.GetComponent<ItemKnifeUI>();
        newItemUI.SetFrame(true);
    }

    private void SuccessBuy(int id)
    {
        Transform item = _baseHolders.GetItemByIndex(id);
        if (item == null) return;

        ItemKnifeUI itemUI = item.GetComponent<ItemKnifeUI>();
        itemUI.SetWrapApple(true);
        itemUI._ItemData.Model.Unlock = true;
    }

    private void LoadItemInShop(KnifesDatabase data)
    {
        foreach (KeyValuePair<int, ItemKnifeDatabase> item in data._Database)
        {
            var clone = Instantiate(_prefab);
            clone.SetParent(_baseHolders.transform);
            var knifeUI = clone.GetComponent<ItemKnifeUI>();

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
}