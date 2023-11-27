using UnityEngine;

public class DeadTrunk : MonoBehaviour
{
    [SerializeField] protected AudioClip _audioClip;

    public void PlaySoundDead()
    {
        AudioManager.Instance.PlaySound(_audioClip);
    }
}