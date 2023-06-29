using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactWheel : BaseImpact
{
    protected override void HitGameObject(Collision2D collision)
    {
        collision.transform.SetParent(this.transform);
    }
}
