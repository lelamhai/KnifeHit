using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedKnife : BaseMonoBehaviour
{
    [SerializeField] private KnifesDatabase _data;
    [SerializeField] private Image _selectedKnife;

    private void OnEnable()
    {
        LoadKnife();
    }

    private void LoadKnife()
    {
        foreach (KeyValuePair<int, ItemKnifeDatabase> item in _data.Database)
        {
            if (item.Value.Model.Use)
            {
                _selectedKnife.sprite = item.Value.Model.Avatar;
            }
        }
    }

    protected override void SetDefaultValue()
    {
        _selectedKnife = transform.GetComponent<Image>();
    }
}