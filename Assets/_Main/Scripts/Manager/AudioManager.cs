using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource _bgSource;
    [SerializeField] private AudioSource _fxSource;
    [SerializeField] private Slider _audioBG;
    [SerializeField] private Slider _audioFX;

    public void PlaySound(AudioClip audioClip)
    {
        _fxSource.PlayOneShot(audioClip);
    }

    //public void AllAudio(float value)
    //{
    //    BGAudio(value);
    //    FXAudio(value);
    //    _soundBG.value = value;
    //    _soundFX.value = value;
    //}

    public void Mute()
    {
        BGAudio(0);
        FXAudio(0);
    }

    public void BGAudio(float value)
    {
        _bgSource.volume = value;
    }

    public void FXAudio(float value)
    {
        _fxSource.volume = value;
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        Transform bg = this.transform.Find("BGAudio");
        _bgSource = bg.GetComponent<AudioSource>();

        Transform fx = this.transform.Find("FXAudio");
        _fxSource = fx.GetComponent<AudioSource>();
    }
}
