using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKnife : BaseMonoBehaviour
{
    [SerializeField] private bool _isMovement = false;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public void SetMovement()
    {
        _isMovement = true;
    }

    private void Update()
    {
        if (!_isMovement) return;
        Movement();
    }

    private void Movement()
    {
        _isMovement = false;
        _rigidbody2D.AddForce(new Vector2(0, _speed), ForceMode2D.Impulse);
    }

    protected override void LoadComponent()
    {
        _rigidbody2D = this.transform.GetComponent<Rigidbody2D>();
    }

    protected override void SetDefaultValue()
    {}
}
