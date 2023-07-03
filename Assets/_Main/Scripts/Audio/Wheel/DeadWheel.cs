using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadWheel : MonoBehaviour
{
    [SerializeField] protected AudioClip _audioClip;

    public void PlaySoundDead()
    {
        AudioManager.Instance.PlaySound(_audioClip);
    }
}
