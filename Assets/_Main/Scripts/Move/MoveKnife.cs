using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKnife : BaseMonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        Debug.Log("MoveKnife");
        Movement();
    }

    private void Movement()
    {
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(new Vector2(0, _speed), ForceMode2D.Impulse);
        _rigidbody2D.gravityScale = 1;
    }

    protected override void SetDefaultValue()
    {
        _rigidbody2D = this.transform.GetComponent<Rigidbody2D>();
    }
}