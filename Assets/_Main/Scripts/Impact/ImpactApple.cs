using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactApple : BaseImpact
{
    protected override void HitGameObject(Collision2D collision)
    {
        Debug.Log("ImpactApple");
    }
}
