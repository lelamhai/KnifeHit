using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] private int _currentRotationElement = 0;
    [SerializeField] private List<RotationElement> _listRotationElement = new List<RotationElement>();

    [SerializeField] private bool _delay = true;
    private float _speed = 0;
    private float _duration = 0;

    [System.Serializable]
    private class RotationElement
    {
        public float Speed;
        public float Duration;
    }


    private void Start()
    {
        _currentRotationElement = Random.Range(0, _listRotationElement.Count - 1);
        _speed = _listRotationElement[_currentRotationElement].Speed;
        _duration = _listRotationElement[_currentRotationElement].Duration;
    }

    private void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(0, 0, _speed * Time.fixedDeltaTime));

        if (!_delay) return;
        StartCoroutine(RandomElement());
    }

    private IEnumerator RandomElement()
    {
        _delay = false;
        _currentRotationElement = Random.Range(0, _listRotationElement.Count);
        _speed = _listRotationElement[_currentRotationElement].Speed;
        Debug.Log("_speed: " + _speed);
        _duration = _listRotationElement[_currentRotationElement].Duration;
        yield return new WaitForSeconds(_duration);
        _delay = true;

    }
}