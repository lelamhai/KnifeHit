using System.Collections.Generic;
using UnityEngine;

public class SpawnKnifeUI : BaseMonoBehaviour
{
    [SerializeField] private Transform _prefab;
    [SerializeField] private Transform _holders;
    [SerializeField] private List<Transform> _poolKnife = new List<Transform>();

    private void OnEnable()
    {
        GameManager.Instance._SetupLevel += SetupLevel;
        InputManager.Instance._Shooting += Shooting;
    }

    private void OnDisable()
    {
        GameManager.Instance._SetupLevel -= SetupLevel;
        InputManager.Instance._Shooting -= Shooting;
    }

    private void Shooting()
    {
        Transform parent = _holders.transform;
        if (parent.childCount <= 0) return;
        Destroy(parent.GetChild(0).gameObject);
    }

    private void SetupLevel(int count)
    {
        if(_holders.childCount < count)
        {
            for (int i = 0; i < _holders.childCount; i++)
            {
                Transform knife = _holders.GetChild(i);
                knife.gameObject.SetActive(true);
            }

            int result = count - _holders.childCount;

            for (int i = 0; i < result; i++)
            {
                Transform knife = Instantiate(_prefab);
                knife.SetParent(_holders.transform);
                knife.localScale = Vector3.one;
                _poolKnife.Add(knife);
            }
        } else if(_holders.childCount > count)
        {
            for (int i = 0; i < count; i++)
            {
                Transform knife = _holders.GetChild(i);
                knife.gameObject.SetActive(true);
            }
        }
    }

    protected override void SetDefaultValue()
    {}
}