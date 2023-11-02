using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAnimator : BaseMonoBehaviour
{
    [SerializeField] protected Animator _animator;


    protected override void SetDefaultValue()
    {
        LoadAnimator();
    }

    private void LoadAnimator()
    {
        _animator = transform.GetComponent<Animator>();
    }
}
