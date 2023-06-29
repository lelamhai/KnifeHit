using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : BaseMonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform _joystick = null;
    [SerializeField] private RectTransform _innerCircle = null;
    public Vector2 _Pos { get; private set; }

    public void OnDrag(PointerEventData eventData)
    {
        CalculateInnerCirclePosition(eventData.position);
        CalculateInputVector();
        CalculateInnerCircleRotation();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _innerCircle.anchoredPosition = Vector2.zero;
        _innerCircle.localRotation = Quaternion.identity;
        _Pos = Vector2.zero;
    }

    private void CalculateInnerCirclePosition(Vector2 position)
    {
        Vector2 directPosition = position - (Vector2)_joystick.position;
        if (directPosition.magnitude > _joystick.rect.width / 2f)
            directPosition = directPosition.normalized * _joystick.rect.width / 2f;
        _innerCircle.anchoredPosition = directPosition;
    }

    private void CalculateInputVector()
    {
        _Pos = _innerCircle.anchoredPosition / (_joystick.rect.size / 2f);
    }

    private void CalculateInnerCircleRotation()
    {
        _innerCircle.localRotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, _Pos));
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        _joystick = this.GetComponent<RectTransform>();
        _innerCircle = this.transform.Find("Inner").GetComponent<RectTransform>();
    }
}
