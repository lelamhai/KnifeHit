using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseLevel : BaseMonoBehaviour
{
    [SerializeField] protected int _countKnifeAvailable = 0;
    [SerializeField] protected int _countApplevalilable = 0;
    [SerializeField] protected int _countKnife = 0;


    protected virtual void SetKnifeAvalilable()
    {

    }

    protected virtual void SetAppleAvalilable()
    {

    }
}
