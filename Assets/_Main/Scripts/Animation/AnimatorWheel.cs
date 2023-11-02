using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorWheel : BaseAnimator
{
    public void HitWheel()
    {
        _animator.SetTrigger("Hit");
    }
}
