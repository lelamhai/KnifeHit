using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeControl : BaseMonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        MoveKnife move = transform.GetComponent<MoveKnife>();
        move.enabled = false;

        BoxCollider2D box = transform.GetComponent<BoxCollider2D>();
        box.enabled = false;

        ImpactKnife knife = transform.GetComponent<ImpactKnife>();
        knife.enabled = true;

        _rigidbody2D.gravityScale = 0;
        _rigidbody2D.velocity = Vector2.zero;

        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    protected override void SetDefaultValue()
    {
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
    }
}
