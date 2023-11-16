using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingWheel : BaseMonoBehaviour
{
    ////[SerializeField] private int _countKnife = 3;

    //[SerializeField] private List<RotationElement> _listRotationElement = new List<RotationElement>();
    //[SerializeField] private int _currentRotationElement = 0;
    //[SerializeField] private bool _delay = true;

    //private float _speed = 0;
    //private float _duration = 0;

    ////private void Start()
    ////{
    ////    GameManager.Instance.SetupLevel(_countKnife);
    ////}

    //private void FixedUpdate()
    //{
    //    this.transform.Rotate(new Vector3(0, 0, _speed * Time.fixedDeltaTime));

    //    if (!_delay) return;
    //    StartCoroutine(RandomElement());
    //}

    //private IEnumerator RandomElement()
    //{
    //    _delay = false;
    //    _currentRotationElement = Random.Range(0, _listRotationElement.Count);
    //    _speed = _listRotationElement[_currentRotationElement].Speed;
    //    _duration = _listRotationElement[_currentRotationElement].Duration;
    //    yield return new WaitForSeconds(_duration);
    //    _delay = true;
    //}

    protected override void SetDefaultValue()
    {}
}

//[System.Serializable]
//struct RotationElement
//{
//    public float Speed;
//    public float Duration;
//}