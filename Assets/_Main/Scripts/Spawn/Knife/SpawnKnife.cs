using System;
using System.Collections.Generic;
using UnityEngine;
public class SpawnKnife : Singleton<SpawnKnife>
{
    [SerializeField] private KnifesDatabase _data;
    [SerializeField] private HoldersKnife _holders;
    [SerializeField] private Transform _point;
    [SerializeField] private TypeKnife _currentKnife = TypeKnife.None;
    [SerializeField] private bool _canShooting = false;
    private int _index = 0;
    private List<Transform> _listItem;

    private void Start()
    {
        SelectedKnife();
    }

    private void OnEnable()
    {
        GameManager.Instance._ChangeKnife += SelectedKnife;

        GameManager.Instance._SetupLevel += SetupLevel;
        InputManager.Instance._Shooting += Shooting;
    }

    private void OnDisable()
    {
        GameManager.Instance._ChangeKnife -= SelectedKnife;

        GameManager.Instance._SetupLevel -= SetupLevel;
        InputManager.Instance._Shooting -= Shooting;
    }

    public void BackHolder()
    {
        _listItem = _holders.GetById((int)_currentKnife);
        foreach (var item in _listItem)
        {
            item.SetParent(this.transform);
            item.gameObject.SetActive(false);
        }

    }

    private void Shooting()
    {
        if (!_canShooting) return;

        List<Transform> list = _holders.GetById((int)_currentKnife);
        if (list.Count <= 0) return;
        if (list.Count <= _index) return;

        var move = list[_index].GetComponent<MoveKnife>();
        move.enabled = true;

        var box = list[_index].GetComponent<BoxCollider2D>();
        box.enabled = true;

        list[_index].parent = null;

        _index++;
    }

    private void SetupLevel(int count)
    {
        _index = 0;
        int hasCount = _holders.GetCountById((int)_currentKnife);
        if (hasCount < count)
        {
            for (int i = 0; i < hasCount; i++)
            {
                Transform knife = _holders.Get((int)_currentKnife);
                knife.position = _point.position;
            }

            int result = count - hasCount;

            for (int i = 0; i < result; i++)
            {
                Transform clone = CloneKnife(_data.Database[(int)_currentKnife].Model.Prefab, _point);
                clone.name = "Knife";
                clone.tag = "Knife";
                _holders.Release((int)_currentKnife, clone);
                clone.gameObject.SetActive(true);
            }
        } else if(hasCount >= count)
        {
            for (int i = 0; i < count; i++)
            {
                Transform knife = _holders.Get((int)_currentKnife);
                knife.position = _point.position;
            }
        }
    }

    private void SelectedKnife()
    {
        foreach (KeyValuePair<int, ItemKnifeDatabase> item in _data.Database)
        {
            if (item.Value.Model.Use)
            {
                _currentKnife = (TypeKnife)item.Value.Model.Id;
                return;
            }
        }
    }

    public void SpawnTypeKnife(TypeKnife typeKnife)
    {
        _currentKnife = typeKnife;
        CloneKnife(_data.Database[(int)_currentKnife].Model.Prefab);
    }

    private Transform CloneKnife(Transform prefab)
    {
        var clone = Instantiate(prefab);
        clone.SetParent(_holders.transform);
        return clone;
    }

    private Transform CloneKnife(Transform prefab, Transform point)
    {
        var clone = Instantiate(prefab);
        clone.position = point.position;
        clone.SetParent(_holders.transform);
        return clone;
    }

    public void SetHolders(Transform knife)
    {
        knife.SetParent(_holders.transform);
    }

    protected override void SetDefaultValue()
    {}
}

public enum TypeKnife
{
    None = -1,
    Knife_01 = 0,
    Knife_02 = 1,
    Knife_03 = 2,
    Knife_04 = 3,
    Knife_05 = 4,
    Knife_06 = 5,
    Knife_07 = 6,
    Knife_08 = 7,
    Knife_09 = 8,
    Knife_10 = 9,
    Knife_11 = 10,
    Knife_12 = 11,
    Knife_13 = 12,
    Knife_14 = 13,
    Knife_15 = 14,
    Knife_16 = 15,
    Knife_17 = 16,
    Knife_18 = 17,
    Knife_19 = 18,
    Knife_20 = 19
}