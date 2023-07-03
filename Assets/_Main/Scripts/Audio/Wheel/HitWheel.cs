using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWheel : MonoBehaviour
{
    [SerializeField] protected AudioClip _audioClip;

    public void PlaySoundHit()
    {
        AudioManager.Instance.PlaySound(_audioClip);
    }
}
