using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject _PrefabImageKnife;
    [SerializeField] private List<GameObject> _listImageKnife = new List<GameObject>();

    private void OnEnable()
    {
        //GameManager.Instance._ResetGame += Setuplevel;
    }

    private void OnDisable()
    {
        //GameManager.Instance._ResetGame -= Setuplevel;
    }

    private void Setuplevel()
    {
        ClearnImageKnife();
        ClearnDataList();
    }

    public void SpawnImageKnife(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var knife = Instantiate(_PrefabImageKnife);
            _listImageKnife.Add(knife);
            knife.transform.SetParent(_parent);
        }
    }

    public void HideImageKnife()
    {
        if(_listImageKnife.Count > 0)
        {
            _listImageKnife[0].SetActive(false);
            _listImageKnife.RemoveAt(0);
        }
    }

    private void ClearnImageKnife()
    {
        if (_parent.childCount > 0)
        {
            foreach (Transform child in _parent)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void ClearnDataList()
    {
        if(_listImageKnife.Count > 0)
        {
            _listImageKnife.Clear();
        }
    }

    public void Shooting()
    {
        InputManager.Instance.Shooting();
    }
}
