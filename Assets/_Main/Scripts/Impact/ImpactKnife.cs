using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactKnife : BaseImpact
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    protected override void HitGameObject(Collision2D collision)
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.isKinematic = true;
    }
}
